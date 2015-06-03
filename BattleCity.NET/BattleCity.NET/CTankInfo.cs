using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BattleCity.NET
{
    public class CTankInfo
    {
        public struct TankStatistics
        {
            public int shotsFired;
			public int successfulShots;
			public int destroyedTanks;
			public int collectedMedicineChest;
			public int collectedAntibonus;
			public int lostHealth;
			public int distanceTraveled;
        }

		private string m_dllName, m_dllPath, m_authorName;

		public CTankInfo(string dllName, Color tankColor)
        {
			m_dllName = Path.GetFileName(dllName);
			Color = tankColor;

			CTankDll tankDll = new CTankDll(dllName);
			m_authorName = tankDll.AuthorName;
			tankDll.Dispose();

			m_dllPath = Path.GetTempFileName();
			File.Copy(dllName, m_dllPath, true);
        }

		~CTankInfo()
		{
			File.Delete(m_dllPath);
		}

		// Путь к DLL, скопированной во временный каталог
        public string DLLPath
        {
            get
            {
                return m_dllPath;
            }
        }

		// Название файла DLL
		public string DLLName
		{
			get
			{
				return m_dllName;
			}
		}

		public string AuthorName
		{
			get
			{
				return m_authorName;
			}
		}

		public Color Color;
        public TankStatistics Statistics;
    }
}
