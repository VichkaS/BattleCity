
#ifdef AIEXAMPLE_EXPORTS
#define AIEXAMPLE_API __declspec(dllexport)
#else
#define AIEXAMPLE_API __declspec(dllimport)
#endif




struct CTankActions
{
	CTankActions():x(0),y(0),baseAngle(0),turretAngle(0),fireAngle(0) {}
	int x;
	int y;
	int baseAngle;
	int turretAngle;
	int fireAngle;
	int movingAngle;
};

extern "C"
{
	AIEXAMPLE_API void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided);
	AIEXAMPLE_API void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses);
	AIEXAMPLE_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints);
	AIEXAMPLE_API void SetBonusCoord(int id, int x, int y);
	AIEXAMPLE_API void SetAntibonusCoord(int id, int x, int y);
	AIEXAMPLE_API int GetDirection();
	AIEXAMPLE_API int GetRotationSpeed();
	AIEXAMPLE_API int GetTurretRotationSpeed();
	AIEXAMPLE_API int GetFireDistance();
	AIEXAMPLE_API void GetAuthorName(char *buffer, size_t buffer_size);
	AIEXAMPLE_API void Update();
}

int CompareAngles(int a, int b);///сравниваем углы


