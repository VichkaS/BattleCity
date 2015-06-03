using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.NET
{
    class CMedicineChest
    {
        private double m_x;
        private double m_y;
       
        private int m_timeBegin;

        private bool CoordinatesIsMatchTanks(List<CTank> Tanks, double tempX, double tempY)
        {
            for (int i = 0; i < Tanks.Count(); ++i)
            {
                if (Math.Abs(tempX - Tanks[i].GetX()) < CConstants.tankSize / 2 && Math.Abs(tempY - Tanks[i].GetY()) < CConstants.tankSize / 2)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CoordinatesIsMatchMedChests(List<CMedicineChest> Chests, double tempX, double tempY)
        {
            for (int i = 0; i < Chests.Count(); ++i)
            {
                if (Math.Abs(tempX - Chests[i].GetX()) < CConstants.medChestsSize / 2 && Math.Abs(tempY - Chests[i].GetY()) < CConstants.medChestsSize / 2)
                {
                    return true;
                }
            }
            return false;
        }

        public CMedicineChest(Random rnd, List<CTank> Tanks, List<CMedicineChest> medChests)
        {
            m_timeBegin = (int)(DateTime.Now.Second);
            double tempX = 0;
            double tempY = 0;
            do
            {
                tempX = rnd.Next(20, CConstants.formWidth - 20);
                tempY = rnd.Next(20, CConstants.formHeight - 20);
            } while (CoordinatesIsMatchTanks(Tanks, tempX, tempY));
            m_x = tempX;
            m_y = tempY;

            
        }

        public CMedicineChest(Random rnd)
        {
            m_timeBegin = (int)(DateTime.Now.Second);
            m_x = rnd.Next(1, 500);
            m_y = rnd.Next(1, 500);


        }

        public double GetX()
        {
            return m_x;
        }

        public double GetY()
        {
            return m_y;
        }

        public bool IsVisible()
        {
            int diff = (int)(DateTime.Now.Second) - m_timeBegin;
            if (diff < 20)
                return true;
            return false;
        }

        public void Draw(Graphics graph, Image m_MedicineChest)
        {
            graph.DrawImage(m_MedicineChest, (float)m_x, (float)m_y);
        }

        public bool CheckCollision(double x, double y)
        {
            if (IsVisible() && Math.Abs(m_x - x) < CConstants.tankSize / 2 && Math.Abs(m_y - y) < CConstants.tankSize / 2)
            {
                return true;
            }
            return false;
        }
    }
}
