﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace BattleCity.NET
{
    public partial class FBattleScreen : Form
    {
		private List<int> m_dead;
		private List<CTankInfo> m_participants;
		private Thread m_RenderThread;
		private List<CTank> m_tanks;
		private List<CShell> m_shells;
		private List<CExplosion> m_explosions;
		private short m_deadPlace = 1;
		private CManagerMedChest m_medChests;
		private Image m_ImageMedicineChest;
		private bool m_isRunning;
		private int m_FPS;

		public FBattleScreen(CMatchParameters parameters, List<CTankInfo> participants)
        {
            InitializeComponent();

			ApplyParameters(parameters);
			m_participants = participants;

			m_ImageMedicineChest = CResourceManager.GetBonus();
            this.Width = CConstants.formWidth + 218;
            this.Height = CConstants.formHeight + 47;
            m_shells = new List<CShell>();
            m_tanks = new List<CTank>();
			m_dead = new List<int>();
            m_explosions = new List<CExplosion>();
			m_isRunning = false;
        }

		private void ApplyParameters(CMatchParameters parameters)
		{
		}

        public static Point[] GetRotatedRectangle(int degree, int size, double x0, double y0)
        {
            int x = -size / 2;
            int y = size / 2;
            double x1 = Math.Cos(degree * Math.PI / 180) * x + Math.Sin(degree * Math.PI / 180) * y;
            double y1 = Math.Sin(degree * Math.PI / 180) * x - Math.Cos(degree * Math.PI / 180) * y;
            x = size / 2;
            y = size / 2;
            double x2 = Math.Cos(degree * Math.PI / 180) * x + Math.Sin(degree * Math.PI / 180) * y;
            double y2 = Math.Sin(degree * Math.PI / 180) * x - Math.Cos(degree * Math.PI / 180) * y;
            x = -size / 2;
            y = -size / 2;
            double x3 = Math.Cos(degree * Math.PI / 180) * x + Math.Sin(degree * Math.PI / 180) * y;
            double y3 = Math.Sin(degree * Math.PI / 180) * y - Math.Cos(degree * Math.PI / 180) * y;
            return new Point[] { new Point(Convert.ToInt32(x0 + x1), Convert.ToInt32(y0 + y1)),
                new Point(Convert.ToInt32(x0 + x2), Convert.ToInt32(y0 + y2)), new Point(Convert.ToInt32(x0 + x3), Convert.ToInt32(y0 + y3)) };
        }

		public void NewMatch(List<int> pIndexes)
        {
			m_tanks.Clear();
			m_shells.Clear();
			m_dead.Clear();
			m_explosions.Clear();
			m_medChests = new CManagerMedChest(m_tanks);

			foreach (int index in pIndexes)
			{
				var tank = new CTank(m_participants[index], m_tanks);
				tank.Index = index;
				m_tanks.Add(tank);
			}

			m_isRunning = true;
			m_RenderThread = new Thread(GameLoop);
			m_RenderThread.Start();
        }

        private void RefreshInterface()
        {
            if (m_tanks.Count < 1) return;
            m_tanks[0].SetTankInfo(pbPlayer1Health, pbPlayer1Reload, lPlayer1Hits, lPlayer1Condition, pbTank1Image, gbPlayer1);
            if (m_tanks.Count < 2) return;
            m_tanks[1].SetTankInfo(pbPlayer2Health, pbPlayer2Reload, lPlayer2Hits, lPlayer2Condition, pbTank2Image, gbPlayer2);
            if (m_tanks.Count < 3) return;
            m_tanks[2].SetTankInfo(pbPlayer3Health, pbPlayer3Reload, lPlayer3Hits, lPlayer3Condition, pbTank3Image, gbPlayer3);
            if (m_tanks.Count < 4) return;
            m_tanks[3].SetTankInfo(pbPlayer4Health, pbPlayer4Reload, lPlayer4Hits, lPlayer4Condition, pbTank4Image, gbPlayer4);
        }

		private void GameLoop()
		{
			Bitmap backgroundImage = CResourceManager.GetBackground(CConstants.formWidth, CConstants.formHeight);
			var formGraphics = this.CreateGraphics();
			Bitmap screen = new Bitmap(CConstants.formWidth, CConstants.formHeight);
			Graphics gr = Graphics.FromImage(screen);

			int ticks;

			while (m_isRunning)
			{
				ticks = Environment.TickCount;

				UpdateScreen();
				if (!m_isRunning)
					break;

				gr.DrawImageUnscaled(backgroundImage, new Point(0, 0));
				//gr.FillRectangle(new SolidBrush(Color.Black), 0, 0, screen.Width, screen.Height);
				foreach (var tank in m_tanks)
				{
					tank.Draw(gr);
				}
				foreach (var shell in m_shells)
				{
					shell.DrawTrack(gr);
					if (shell.IsVisible())
						shell.Draw(gr);
				}
				foreach (var explosion in m_explosions)
				{
					explosion.Draw(gr);
				}
				m_medChests.DrawAllMedchests(gr, m_tanks, m_ImageMedicineChest);

				if (m_isRunning)
					formGraphics.DrawImageUnscaled(screen, new Point(0, 0));

				int oldTicks = ticks;
				ticks = Environment.TickCount;
				int sleepTime = CConstants.refreshTime - (ticks - oldTicks);
				if (sleepTime > 0)
				{
					Thread.Sleep(sleepTime);
				}
			}
		}

        private void RefreshTanks()
        {
            for (int i = 0; i < m_tanks.Count; i++)
            {
                m_tanks[i].Actions(m_tanks, m_shells, m_medChests);
            }
        }

        private void ExplosionDamage(double x, double y, CTank tank, CShell shell)
        {
            if (tank != null && !tank.IsDead())
            {
                if (tank.CheckCollision(x, y, CConstants.tankSize / 2)) //прямое попадание
                {
                    tank.SetDamage(10);
                }
                if (tank.CheckCollision(x, y, CConstants.tankSize)) //в половине корпуса от танка
                {
                    tank.SetDamage(5);
                }
                if (tank.CheckCollision(x, y, 3 * CConstants.tankSize / 2)) //в корпусе от танка
                {
                    tank.SetDamage(5);
                    shell.SuccessfulyHits();
                }
                if (tank.IsDead())
                {
					m_dead.Add(tank.Index);
                    tank.SetDeadPlace(m_deadPlace);
                    m_deadPlace++;
                }
            }
        }

        private void RefreshShells()
        {
            for (int i = 0; i < m_shells.Count; i++)
            {
                if (m_shells[i].IsVisible())
                {
                    m_shells[i].MoveShell();
                    if (m_shells[i].IsExploded())
                    {
                        for (int j = 0; j < m_tanks.Count; j++)
                        {
                            ExplosionDamage(m_shells[i].GetX(), m_shells[i].GetY(), m_tanks[j], m_shells[i]);
                        }
                        m_explosions.Add(m_shells[i].GetExplosion());
                    }
                    if (m_shells[i].OutOfField() || m_shells[i].IsExploded())
                    {
                        //   shells.RemoveAt(i);
                       m_shells[i].SetNotVisible();
                
                    }
                }
                else if (!m_shells[i].TrackIsVisible())
                {
                        m_shells.RemoveAt(i);
                } 
            }
        }

        public void RefreshExplosions()
        {
            for (int i = 0; i < m_explosions.Count; i++)
            {
                m_explosions[i].Update();
                if (m_explosions[i].IsEnded())
                {
                    m_explosions.RemoveAt(i);
                }
            }
        }

        private void CheckForError()
        {
            if (CConstants.error == 0)
            {
                return;
            }
            m_isRunning = false;
            DialogResult result = DialogResult.OK;
            if (CConstants.error == 1)
            {
                result = MessageBox.Show(this, "Cannot open image", "File not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CConstants.error == 2)
            {
                result = MessageBox.Show(this, "Cannot find function in dll", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                result = MessageBox.Show(this, "Unknown error", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private bool GameOver()
        {
            int alivePlayers = 0;
            for(int i = 0; i < m_tanks.Count; i++)
            {
                if (!m_tanks[i].IsDead())
                {
                    alivePlayers++;
                }
            }
            if (alivePlayers < 2)
            {
                return true;
            }
            return false;
        }

        public List<int> GetWinners()
        {
			var winners = new List<int>(m_dead);

			foreach (var tank in m_tanks)
			{
				if (!tank.IsDead())
				{
					winners.Add(tank.Index);
				}
			}

			winners.Reverse();
			return winners;
        }

        private void UpdateScreen()
        {
			m_FPS++;

            CheckForError();
            if (GameOver())
            {
				m_isRunning = false;
				return;
				/*
                DialogResult result = MessageBox.Show(this, "Do you want to play another game?", GetWinner() + ". Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    this.Owner.Show();
                    return;
                }
                else
                {
                    Application.Exit();
                    return;
                }*/
            }

            Random rnd = new Random();
            if (rnd.Next(1, 1000) <= 10)
            {
                m_medChests.AddMedChest();
            }
            RefreshTanks();
            RefreshShells();
            RefreshExplosions();
        }

        private void FBattleScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
			m_isRunning = false;
			//this.Close();
            /*if (m_IsRunning)
            {
                Application.Exit();
            }*/
        }

		private void tFPS_Tick(object sender, EventArgs e)
		{
			//lFPS.Text = "FPS: " + m_FPS.ToString();
			this.Text = "FPS: " + m_FPS.ToString();
			m_FPS = 0;	
		}

		//private void FBattleScreen_Shown(object sender, EventArgs e)
		//{
		//	
		//}

		private void FBattleScreen_FormClosed(object sender, FormClosedEventArgs e)
		{
			m_isRunning = false;
			foreach (var tank in m_tanks)
			{
				tank.Dispose();
			}
		}

		private void tUpdateInterface_Tick(object sender, EventArgs e)
		{
			if (!m_isRunning)
			{
				this.Close();
			}
			else
			{
				RefreshInterface();
			}
		}

    }
}
