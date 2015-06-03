using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity.NET
{
    class CManagerMedChest
    {
        List<CMedicineChest> m_MedicineChests;
        Random rnd;
        List<CTank> m_Tanks;
        public CManagerMedChest(List<CTank> Tanks)
        {
            rnd = new Random();
            m_MedicineChests = new List<CMedicineChest>();
            //m_MedicineChests.Add(new CMedicineChest(rnd));
            m_Tanks = Tanks;
        }

        public List<CMedicineChest> GetMedicineChests()
        {
            return m_MedicineChests;
        }

        public void AddMedChest()
        {
            m_MedicineChests.Add(new CMedicineChest(rnd, m_Tanks, m_MedicineChests));
        }

        public void DrawAllMedchests(Graphics e, List<CTank> Tanks, Image imageMedChest)
        {
            List<int> tmp = new List<int>();
            for (int i = 0; i < m_MedicineChests.Count(); ++i)
            {
                for (int k = 0; k < Tanks.Count(); ++k)
                {
                    if (m_MedicineChests[i].IsVisible() && !m_MedicineChests[i].CheckCollision(Tanks[k].GetX(), Tanks[k].GetY()))
                    {
                        m_MedicineChests[i].Draw(e, imageMedChest);
                    }
                    else if (m_MedicineChests[i].IsVisible() && m_MedicineChests[i].CheckCollision(Tanks[k].GetX(), Tanks[k].GetY()))
                    {
                        Tanks[k].SetHealth(10);
                        if (!tmp.Contains(i))
                            tmp.Add(i);
                    }
                    else
                    {
                        if (!tmp.Contains(i))
                            tmp.Add(i);
                       // break;

                    }
                }
            }
            //foreach (int i in tmp)
            for (int i = 0; i < tmp.Count; ++i)
            {
                m_MedicineChests.RemoveAt(tmp[i]);
            }
        }
    }
}
