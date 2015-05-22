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

		string ErrorText
		{
			get
			{
				return m_error;
			}
		}

		string DllFileName
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
		delegate void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SetCoordinatesChest(int id, int x, int y);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetDirection();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetRotateDirection();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetRotateSpeed();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetTurretRotateDirection();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetTurretRotateSpeed();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int GetFireDistance();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void SetVisibleChests(int count);
		
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void Update();

		public CTankDll(string dllName)
		{
			m_FileName = dllName;
			m_Handle = LoadLibrary(m_FileName);

			if (m_Handle == IntPtr.Zero)
			{
				throw new DllException("LoadLibrary failed", m_FileName);
			}

			//setcoords = (SetCoords)GetFunction(m_Handle, typeof(SetCoords), "SetCoords");
			//setangle = (SetAngle)GetFunction(m_Handle, typeof(SetAngle), "SetAngle");
			//setturrentAngle = (SetTurretAngle)GetFunction(m_Handle, typeof(SetTurretAngle), "SetTurretAngle");
			//setcollisionstatus = (SetCollisionStatus)GetFunction(m_Handle, typeof(SetCollisionStatus), "SetCollisionStatus");
			//setlivepercent = (SetLivePercent)GetFunction(m_Handle, typeof(SetLivePercent), "SetLivePercent");
			//setvisibleenemycount = (SetVisilbeEnemyCount)GetFunction(m_Handle, typeof(SetVisilbeEnemyCount), "SetVisilbeEnemyCount");
			setenemyproteries = (SetEnemyProperties)GetFunction(m_Handle, typeof(SetEnemyProperties), "SetEnemyProteries");
			update = (Update)GetFunction(m_Handle, typeof(Update), "Update");
			getrotatedirection = (GetRotateDirection)GetFunction(m_Handle, typeof(GetRotateDirection), "GetRotateDirection");
			getrotatespeed = (GetRotateSpeed)GetFunction(m_Handle, typeof(GetRotateSpeed), "GetRotateSpeed");
			getdirection = (GetDirection)GetFunction(m_Handle, typeof(GetDirection), "GetDirection");
			getturretrotatedirection = (GetTurretRotateDirection)GetFunction(m_Handle, typeof(GetTurretRotateDirection), "GetTurretRotateDirection");
			getturretrotatespeed = (GetTurretRotateSpeed)GetFunction(m_Handle, typeof(GetTurretRotateSpeed), "GetTurretRotateSpeed");
			getfiredistance = (GetFireDistance)GetFunction(m_Handle, typeof(GetFireDistance), "GetFireDistance");
			setcoordinateschest = (SetCoordinatesChest)GetFunction(m_Handle, typeof(SetCoordinatesChest), "SetCoordinatesChest");
			setvisiblechests = (SetVisibleChests)GetFunction(m_Handle, typeof(SetVisibleChests), "SetVisibleChests");
		}

		private System.Delegate GetFunction(IntPtr dll, Type type, string functionName)
		{
			IntPtr ptr = GetProcAddress(dll, functionName);

			if (ptr == IntPtr.Zero)
			{
				throw new DllException(String.Format("Function \"{0}\" not fopund in library", functionName), m_FileName);
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

		//SetCoords setcoords;
		//SetAngle setangle;
		//SetTurretAngle setturrentAngle;
		//SetCollisionStatus setcollisionstatus;
		//SetLivePercent setlivepercent;
		//SetVisilbeEnemyCount setvisibleenemycount;
		SetEnemyProperties setenemyproteries;
		Update update;
		GetRotateDirection getrotatedirection;
		GetRotateSpeed getrotatespeed;
		GetDirection getdirection;
		GetTurretRotateDirection getturretrotatedirection;
		GetTurretRotateSpeed getturretrotatespeed;
		GetFireDistance getfiredistance;
		SetCoordinatesChest setcoordinateschest;
		SetVisibleChests setvisiblechests;
	}
}
