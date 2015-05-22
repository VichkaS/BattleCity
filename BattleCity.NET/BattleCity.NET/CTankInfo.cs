using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BattleCity.NET
{
    class CTankInfo
    {
        struct TankStatistics
        {
            int shotsFired;
            int successfulShots;
            int destroyedTanks;
            int collectedMedicineChest;
            int collectedAntibonus;
            int lostHealth;
            int distanceTraveled;
        }
        private string m_dllPath;
        private Color m_color;
        
        public CTankInfo(string dll, Color tankColor)
        {
            m_dllPath = dll; 
            m_color = tankColor; 
        }

        public string DLLPath 
        {
            get
            {
                return m_dllPath;
            }
        }

        public Color Color
        {
            get
            {
                return m_color;
            }
        }
        public TankStatistics Statistics;
    }
}
