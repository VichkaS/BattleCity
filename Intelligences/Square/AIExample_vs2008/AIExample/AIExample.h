
#ifdef AIEXAMPLE_EXPORTS
#define AIEXAMPLE_API __declspec(dllexport)
#else
#define AIEXAMPLE_API __declspec(dllimport)
#endif


struct CTankActions
{
	CTankActions():x(0), y(0),baseAngle(0),turretAngle(0), fireAngle(0), movingAngle(0) {}
	int x;
	int y;
	int baseAngle;
	int turretAngle;
	int fireAngle;
	int movingAngle;
};

extern "C"
{
	AIEXAMPLE_API void SetCoords(int x, int y);
	AIEXAMPLE_API void SetAngle(int angle);
	AIEXAMPLE_API void SetTurretAngle(int angle);
	AIEXAMPLE_API void SetCollisionStatus(bool isCollided);
	AIEXAMPLE_API void SetLivePercent(int percent);
	AIEXAMPLE_API void SetVisilbeEnemyCount(int count);
	AIEXAMPLE_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent);
	AIEXAMPLE_API void SetCoordinatesChest(int id, double x, double y);
	AIEXAMPLE_API void SetVisibleChest(int count);
	AIEXAMPLE_API int GetDirection();
	AIEXAMPLE_API int GetRotateDirection();
	AIEXAMPLE_API int GetRotateSpeed();
	AIEXAMPLE_API int GetTurretRotateDirection();
	AIEXAMPLE_API int GetTurretRotateSpeed();
	AIEXAMPLE_API int GetFireDistance();
	AIEXAMPLE_API void Update();
}


