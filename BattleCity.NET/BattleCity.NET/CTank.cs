using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace BattleCity.NET
{
    class CTank : IDisposable
    {
        public CTank(CTankInfo tankInfo, List<CTank> tanks)
        {
			m_dll = new CTankDll(tankInfo.DLLPath);

			m_base = CResourceManager.GetTankBase(tankInfo.Color);
			m_turret = CResourceManager.GetTankTurret(tankInfo.Color);
			m_tank = CResourceManager.GetTank(tankInfo.Color);
			
			Random rnd = new Random();
            int triescount = 0;
            do
            {
                m_x = rnd.Next(CConstants.formWidth - CConstants.tankSize) + CConstants.tankSize / 2;
                m_y = rnd.Next(CConstants.formHeight - CConstants.tankSize) + CConstants.tankSize / 2;
                triescount++;
            } while (!PlacementIsFree(m_x, m_y, tanks) && triescount < 500);
            m_health = 100;
            m_hits = 0;
            m_baseDirection = rnd.Next(360);
            m_turretDirection = m_baseDirection;
            m_deadPlace = -1;
            m_reload = CConstants.reloadTime;
            m_destroyed = false;
        }
        
        private bool PlacementIsFree(double x, double y, List<CTank> tanks)
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CheckCollision(x, y, 2 * CConstants.tankSize))
                {
                    return false;
                }
            }
            return true;
        }

        private List<CTank> GetEnemies(List<CTank> tanks)
        {
            List<CTank> enemies = new List<CTank>();
            for (int i = 0; i < tanks.Count; i++)
            {
                int x0 = Convert.ToInt32(tanks[i].m_x - m_x); //проекция вектора, соединяющего текущий танк со врагом на ось х
                int y0 = -Convert.ToInt32(tanks[i].m_y - m_y); //проекция вектора, соединяющего текущий танк со врагом на ось у
                double angle = -Math.Atan2(y0, x0) * 180 / Math.PI + 90;//угол этого самого вектора
                while (angle < 360)
                {
                    angle += 360;
                }
                while (m_baseDirection < 360)
                {
                    m_baseDirection += 360;
                }
                if ((angle > (m_baseDirection - 45) && angle < (m_baseDirection + 45))
                    || ((angle % 360) > (m_baseDirection - 45) && (angle % 360) < (m_baseDirection + 45))
                    || (angle > (m_baseDirection % 360 - 45) && angle < (m_baseDirection % 360 + 45)))
                {
                    if (!(tanks[i].m_x == m_x && tanks[i].m_y == m_y) && !tanks[i].IsDead())//это мы сами или труп
                    {
                        enemies.Add(tanks[i]);
                    }
                }
                m_baseDirection %= 360;
            }
            return enemies;
        }

        private void TryToMoveForward(double x, double y, List<CTank> tanks)
        {
            bool ableToMove = true;
            bool ableToMoveX = true;
            bool ableToMoveY = true;
            for(int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] != this)
                {
                    if (tanks[i].CheckCollision(m_x + x, m_y - y, CConstants.tankSize))
                    {
                        ableToMove = false;
                        if (tanks[i].IsDead())
                        {
                            tanks[i].m_destroyed = true;
                            ableToMove = true;
                        }
                    }
                }
            }
            if (ableToMove)
            {
                m_x += x;
                m_y -= y;
                return;
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] != this)
                {
                    if (tanks[i].CheckCollision(m_x + x, m_y, CConstants.tankSize))
                    {
                        ableToMoveX = false;
                    }
                }
            }
            if (ableToMoveX)
            {
                m_x += x;
                return;
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] != this)
                {
                    if (tanks[i].CheckCollision(m_x, m_y - y, CConstants.tankSize))
                    {
                        ableToMoveY = false;
                    }
                }
            }
            if (ableToMoveY)
            {
                m_y -= y;
            }
        }

        public void Actions(List<CTank> tanks, List<CShell> shells, CManagerMedChest medChests)
        {
            if (IsDead())
            {
                m_reload = 0;
                return;
            }
            if (m_reload > 0)
            {
                m_reload--;
            }
            
            List<CTank> visibleEnemies = GetEnemies(tanks);
            List<CMedicineChest> allChest = medChests.GetMedicineChests();

            int distance = -1;
            try
            {
				m_dll.SetStatus(Convert.ToInt32(m_x), Convert.ToInt32(m_y), m_baseDirection, m_turretDirection, m_health, DetectCollisions(tanks));

				m_dll.SetObjectCount(visibleEnemies.Count(), allChest.Count(), 0);
                for (int i = 0; i < allChest.Count(); ++i)
                {
					m_dll.SetBonusCoord(i, Convert.ToInt32(allChest[i].GetX()), Convert.ToInt32(allChest[i].GetY()));
                }
				
                for (int i = 0; i < visibleEnemies.Count; i++)
                {
					m_dll.SetEnemyProperties(i, Convert.ToInt32(visibleEnemies[i].m_x), Convert.ToInt32(visibleEnemies[i].m_y),
						visibleEnemies[i].m_baseDirection, visibleEnemies[i].m_turretDirection, visibleEnemies[i].m_health);
                }
                m_dll.Update();

                int rotationSpeed = m_dll.GetRotationSpeed();
                if (rotationSpeed > 10)
                {
                    rotationSpeed = 10;
                }
                else if (rotationSpeed < -10)
                {
                    rotationSpeed = -10;
                }
                m_baseDirection += Convert.ToInt32(rotationSpeed * CConstants.baseRotationRate + 360) % 360;
				
                int dir = m_dll.GetDirection();
                if (dir > 1)
                {
                    dir = 1;
                }
                else if (dir < -1)
                {
                    dir = -1;
                }
				TryToMoveForward(dir * CConstants.tankSpeed * Math.Sin(m_baseDirection * Math.PI / 180),
					dir * CConstants.tankSpeed * Math.Cos(m_baseDirection * Math.PI / 180), tanks);
                FixCollisions(tanks);

                int turretRotationSpeed = m_dll.GetTurretRotationSpeed();
                if (turretRotationSpeed > 20)
                {
                    turretRotationSpeed = 20;
                }
                else if (turretRotationSpeed < -20)
                {
                    turretRotationSpeed = -20;
                }
                m_turretDirection += Convert.ToInt32(turretRotationSpeed * CConstants.turretRotationRate + 360) % 360;
				
                distance = m_dll.GetFireDistance();
                if (distance < -1)
                {
                    distance = -1;
                }

            }
            catch
            {
                CConstants.error = 2;
                return;
            }

            if (distance != -1 && m_reload == 0)
            {
                shells.Add(new CShell(Convert.ToInt32(m_x), Convert.ToInt32(m_y), m_turretDirection, distance, this));
                m_reload = CConstants.reloadTime;
            }
        }

		private void DrawProgressBar(Graphics graph, int elevation, int value, int valueMax)
		{
			int pbLength = Convert.ToInt32((value * 60f) / valueMax);
			Color pbColor = pbLength <= 15 ? Color.Red : Color.Green;

			graph.FillRectangle(new SolidBrush(pbColor), (int)m_x - 30, (int)m_y - elevation, pbLength, 10);
			graph.DrawRectangle(new Pen(Color.White),    (int)m_x - 30, (int)m_y - elevation, 60,       10);
		}

        public void Draw(Graphics graph)
        {
            if (m_destroyed)
            {
                return;
            }

            if (!IsDead())
            {
                graph.DrawImage(m_base, FBattleScreen.GetRotatedRectangle(m_baseDirection, CConstants.tankSize, m_x, m_y));
                graph.DrawImage(m_turret, FBattleScreen.GetRotatedRectangle(m_turretDirection, CConstants.turretSize, m_x, m_y));

				DrawProgressBar(graph, 60, m_health, 100);
				DrawProgressBar(graph, 47, m_reload, CConstants.reloadTime);
            }
            else
            {
                graph.DrawImage(CConstants.wrecked, FBattleScreen.GetRotatedRectangle(m_baseDirection, CConstants.tankSize, m_x, m_y));
            }
        }

        public void SetTankInfo(ProgressBar pbHealth, ProgressBar pbReload, Label hits, Label condition, PictureBox pbox, GroupBox gb)
        {
            pbHealth.Value = m_health;
            pbReload.Value = m_reload * pbReload.Maximum / CConstants.reloadTime;
            Color color =  (m_health < 40 ) ? Color.Red : Color.Green;
            hits.Text = Convert.ToString(m_hits);
            if (!IsDead())
            {
                condition.Text = "Still alive";
            }
            else
            {
                condition.Text = "Dead " + Convert.ToString(m_deadPlace);
            }
            pbox.Image = m_tank;
            gb.Visible = true;
        }

        public bool CheckCollision(double x, double y, int length)
        {
            if (!m_destroyed && Math.Abs(m_x - x) < length && Math.Abs(m_y - y) < length)
            {
                return true;
            }
            return false;
        }

        public bool FixCollisions(List<CTank> tanks)
        {
            bool result = false;
            if (m_x < CConstants.tankSize / 2)
            {
                m_x = CConstants.tankSize / 2;
                result = true;
            }
            if (m_x > CConstants.formWidth - CConstants.tankSize / 2)
            {
                m_x = CConstants.formWidth - CConstants.tankSize / 2;
                result = true;
            }
            if (m_y < CConstants.tankSize / 2)
            {
                m_y = CConstants.tankSize / 2;
                result = true;
            }
            if (m_y > CConstants.formHeight - CConstants.tankSize / 2)
            {
                m_y = CConstants.formHeight - CConstants.tankSize / 2;
                result = true;
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CheckCollision(m_x, m_y, CConstants.tankSize / 2) && !(m_x == tanks[i].m_x && m_y == tanks[i].m_y))
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DetectCollisions(List<CTank> tanks)
        {
            if (m_x <= CConstants.tankSize / 2 || m_y <= CConstants.tankSize / 2 || m_x >= CConstants.formWidth - CConstants.tankSize / 2 ||
                m_y >= CConstants.formHeight - CConstants.tankSize / 2)
            {
                return true; //collision with borders
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CheckCollision(m_x, m_y, CConstants.tankSize + CConstants.tankSpeed))//collision with tanks
                {
                    if (!(tanks[i] == this))//it's not me
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void SetDamage(short damage)
        {
            if(m_health < 0)
            {
                return;
            }
            m_health -= damage;
            if (m_health < 0)
            {
                m_health = 0;
				CResourceManager.Instance.PlaySound(CResourceManager.SoundEffect.PlayerDeath);
            }
        }

		public double GetX()
		{
			return m_x;
		}

        public double GetY()
        {
            return m_y;
        }

        public void SetHealth(short health)
        {
            if (IsDead())
            {
                return;
            }
            if (m_health <= 90)
            {
                m_health += health;
            }
            else if (m_health > 90)
            {
                m_health = 100;
            }
        }

        public bool IsDead()
		{
			return m_health <= 0;
		}

        public void SetDeadPlace(short deadNumber)
		{
			m_deadPlace = deadNumber;
		}

        public void SuccessfulHit()
		{
			m_hits++;
		}

		public void Dispose()
		{
			if (m_dll != null)
			{
				m_dll.Dispose();
				m_dll = null;
			}
		}

		private CTankDll m_dll;
        private bool m_destroyed;
        private readonly Image m_base;
        private readonly Image m_turret;
        private readonly Image m_tank;
        private double m_x;
        private double m_y;
        private short m_health;
        private short m_hits;
        private short m_reload;
        private int m_baseDirection;
        private int m_turretDirection;
        private short m_deadPlace;
    }
}
