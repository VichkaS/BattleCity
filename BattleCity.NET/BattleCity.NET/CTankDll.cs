using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BattleCity.NET
{
	class DllException : Exception
	{
		private string m_error, m_dllName;

		public DllException(string error, string dllName)
			: base(String.Format("Error while trying to load \"{0}\":\n{1}", dllName, error))
		{
			m_error = error;
			m_dllName = dllName;
		}

		public string ErrorText
		{
			get
			{
				return m_error;
			}
		}

		public string DllFileName
		{
			get
			{
				return m_dllName;
			}
		}
	}

	class CTankDll : IDisposable
	{
		[DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
		static extern IntPtr LoadLibrary(string libraryName);
		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
		static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
		[DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
		static extern bool FreeLibrary(IntPtr hModule);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void pSetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void pSetObjectCount(int visibleEnemies, int bonuses, int antibonuses);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void pSetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void pSetCoord(int id, int x, int y);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int pGetInt();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public delegate string pGetAuthorName(StringBuilder sb, uint bufferSize);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void pUpdate();

		public CTankDll(string dllName)
		{
			m_FileName = dllName;
			m_Handle = LoadLibrary(m_FileName);

			if (m_Handle == IntPtr.Zero)
			{
				throw new DllException("LoadLibrary failed", m_FileName);
			}

			SetStatus = (pSetStatus)GetFunction(m_Handle, typeof(pSetStatus), "SetStatus");
			SetObjectCount = (pSetObjectCount)GetFunction(m_Handle, typeof(pSetObjectCount), "SetObjectCount");
			SetEnemyProperties = (pSetEnemyProperties)GetFunction(m_Handle, typeof(pSetEnemyProperties), "SetEnemyProperties");
			SetBonusCoord = (pSetCoord)GetFunction(m_Handle, typeof(pSetCoord), "SetBonusCoord");
			SetAntibonusCoord = (pSetCoord)GetFunction(m_Handle, typeof(pSetCoord), "SetAntibonusCoord");

			GetDirection = (pGetInt)GetFunction(m_Handle, typeof(pGetInt), "GetDirection");
			GetRotationSpeed = (pGetInt)GetFunction(m_Handle, typeof(pGetInt), "GetRotationSpeed");
			GetTurretRotationSpeed = (pGetInt)GetFunction(m_Handle, typeof(pGetInt), "GetTurretRotationSpeed");
			GetFireDistance = (pGetInt)GetFunction(m_Handle, typeof(pGetInt), "GetFireDistance");
			pGetAuthorName GetAuthorName = (pGetAuthorName)GetFunction(m_Handle, typeof(pGetAuthorName), "GetAuthorName");
			
			Update = (pUpdate)GetFunction(m_Handle, typeof(pUpdate), "Update");

			StringBuilder sb = new StringBuilder(100);
			GetAuthorName(sb, 100);
			m_authorName = sb.ToString();
		}

		private Delegate GetFunction(IntPtr hDll, Type type, string functionName)
		{
			IntPtr ptr = GetProcAddress(hDll, functionName);

			if (ptr == IntPtr.Zero)
			{
				throw new DllException(String.Format("Function \"{0}\" not found in library", functionName), m_FileName);
			}

			return Marshal.GetDelegateForFunctionPointer(ptr, type);
		}

		~CTankDll()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (m_Handle != IntPtr.Zero)
			{
				FreeLibrary(m_Handle);
				m_Handle = IntPtr.Zero;
			}
		}

		private IntPtr m_Handle;
		private string m_FileName;
		private string m_authorName;

		public string AuthorName
		{
			get
			{
				return m_authorName;
			}
		}

		public readonly pSetStatus SetStatus;
		public readonly pSetObjectCount SetObjectCount;
		public readonly pSetEnemyProperties SetEnemyProperties;
		public readonly pSetCoord SetBonusCoord;
		public readonly pSetCoord SetAntibonusCoord;
		public readonly pGetInt GetDirection;
		public readonly pGetInt GetRotationSpeed;
		public readonly pGetInt GetTurretRotationSpeed;
		public readonly pGetInt GetFireDistance;
		public readonly pUpdate Update;
	}
}
