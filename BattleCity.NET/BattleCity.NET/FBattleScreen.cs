using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattleCity.NET
{
    public partial class FBattleScreen : Form
    {
        public FBattleScreen(int countTanks)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.BackgroundImageLayout = ImageLayout.None;

			this.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("fon"); 
			m_ImageMedicineChest = (Bitmap)Properties.Resources.ResourceManager.GetObject("MedicineChest");

            tRender.Interval = CConstants.refreshTime;
            this.Width = CConstants.formWidth + 218;
            this.Height = CConstants.formHeight + 47;
            shells = new List<CShell>();
            tanks = new List<CTank>();
            explosions = new List<CExplosion>();
			CResourceManager.Instance.PlaySound(CResourceManager.SoundEffect.GameStart);
            m_medChests = new CManagerMedChest(tanks);
            for (int i = 0; i < 4; ++i)
            {
                listProgressBar.Add(new CProgressBar());
                listProgressBarHealth.Add(new CProgressBar());
                if (i < countTanks)
                {
                    this.Controls.Add(listProgressBar[i]);
                    this.Controls.Add(listProgressBarHealth[i]);
                }
             }
        }
        List<CProgressBar> listProgressBar = new List<CProgressBar>();
        List<CProgressBar> listProgressBarHealth = new List<CProgressBar>();
        private List<CTank> tanks;
        private List<CShell> shells;
        private List<CExplosion> explosions;
        private short deadPlace = 1;
        private CManagerMedChest m_medChests;
        private  Image m_ImageMedicineChest;
        
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

        public void NewTank(string dll, string image)
        {
            tanks.Add(new CTank(dll, image, tanks)); 
        }

        private void RefreshInterface()
        {
          
            if (tanks.Count < 1) return;
            tanks[0].SetTankInfo(pbPlayer1Health, pbPlayer1Reload, lPlayer1Hits, lPlayer1Condition, pbTank1Image, gbPlayer1, listProgressBar[0], listProgressBarHealth[0]);
            if (tanks.Count < 2) return;
            tanks[1].SetTankInfo(pbPlayer2Health, pbPlayer2Reload, lPlayer2Hits, lPlayer2Condition, pbTank2Image, gbPlayer2, listProgressBar[1], listProgressBarHealth[1]);
            if (tanks.Count < 3) return;
            tanks[2].SetTankInfo(pbPlayer3Health, pbPlayer3Reload, lPlayer3Hits, lPlayer3Condition, pbTank3Image, gbPlayer3, listProgressBar[2], listProgressBarHealth[2]);
            if (tanks.Count < 4) return;
            tanks[3].SetTankInfo(pbPlayer4Health, pbPlayer4Reload, lPlayer4Hits, lPlayer4Condition, pbTank4Image, gbPlayer4, listProgressBar[3], listProgressBarHealth[3]);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].Draw(e.Graphics);
            }
            for (int i = 0; i < shells.Count; i++)
            {
                shells[i].DrawTrack(e.Graphics);
                if (shells[i].IsVisible())
                    shells[i].Draw(e.Graphics);
            }
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Draw(e.Graphics);
            }
            m_medChests.DrawAllMedchests(e.Graphics, tanks, ref m_ImageMedicineChest);
        }
        private void RefreshTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].Actions(tanks, shells, m_medChests);
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
                    tank.SetDeadPlace(deadPlace);
                    deadPlace++;
                }
            }
        }

        private void RefreshShells()
        {
            for (int i = 0; i < shells.Count; i++)
            {
                if (shells[i].IsVisible())
                {
                    shells[i].MoveShell();
                    if (shells[i].IsExploded())
                    {
                        for (int j = 0; j < tanks.Count; j++)
                        {
                            ExplosionDamage(shells[i].GetX(), shells[i].GetY(), tanks[j], shells[i]);
                        }
                        explosions.Add(shells[i].GetExplosion());
                    }
                    if (shells[i].OutOfField() || shells[i].IsExploded())
                    {
                        //   shells.RemoveAt(i);
                       shells[i].SetNotVisible();
                
                    }
                }
                else if (!shells[i].TrackIsVisible())
                {
                        shells.RemoveAt(i);
                } 
            }
        }
        public void RefreshExplosions()
        {
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Update();
                if (explosions[i].IsEnded())
                {
                    explosions.RemoveAt(i);
                }
            }
        }

        private void CheckForError()
        {
            if (CConstants.error == 0)
            {
                return;
            }
            tRender.Enabled = false;
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
            for(int i = 0; i < tanks.Count; i++)
            {
                if (!tanks[i].IsDead())
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

        private string GetWinner()
        {
            int winnerIndex = -1;
            for (int i = 0; i < tanks.Count; i++)
            {
                if (!tanks[i].IsDead())
                {
                    winnerIndex = i + 1;
                }
            }
            if (winnerIndex == -1)
            {
                return "No one survived";
            }
            return "Player " + Convert.ToString(winnerIndex) + " wins";
        }

		private int m_FPS;
        private void timer1_Tick(object sender, EventArgs e)
        {
			m_FPS++;

            CheckForError();
            if (GameOver())
            {
                tRender.Enabled = false;
				CResourceManager.Instance.PlaySound(CResourceManager.SoundEffect.GameOver);
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
                }
            }
            Random rnd = new Random();
            if (rnd.Next(1, 1000) <= 10)
            {
                m_medChests.AddMedChest();
            }
            RefreshTanks();
            RefreshShells();
            RefreshExplosions();
            RefreshInterface();
            this.Refresh();
        }

        private void FBattleScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tRender.Enabled)
            {
                Application.Exit();
            }
        }

		private void tFPS_Tick(object sender, EventArgs e)
		{
			lFPS.Text = "FPS: " + m_FPS.ToString();
			m_FPS = 0;
		}

    }
}