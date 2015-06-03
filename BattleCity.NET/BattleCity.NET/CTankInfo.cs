using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity.NET
{
    class CTankInfo
    {
        public struct TankStatistics
        {
            int shotsFired;
            int successfulShots;
            int destroyedTanks;
            int collectedMedicineChest;
            int collectedAntibonus;
            int lostHealth;
            int distanceTraveled;
        }

		private string m_dllPath, m_authorName;
        private Color m_color;

		public CTankInfo(string dllName, Color tankColor)
        {
			m_dllPath = dllName;
            m_color = tankColor;

			CTankDll tankDll = new CTankDll(dllName);
			m_authorName = tankDll.AuthorName;
			tankDll.Dispose();
        }

        public string DLLPath
        {
            get
            {
                return m_dllPath;
            }
        }

		public string AuthorName
		{
			get
			{
				return m_authorName;
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
