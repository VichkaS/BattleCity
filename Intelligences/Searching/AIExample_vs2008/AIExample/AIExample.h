// This class is exported from the dll_example.dll
#ifdef AIEXAMPLE_EXPORTS
#define AI_API __declspec(dllexport) 
#else
#define AI_API __declspec(dllimport) 
#endif
#include <vector>


enum strategy
{
	searching, //Rotating until we can see something
	camping //Stay and shoot
};

struct enemy
{
	int x;
	int y;
	int health;
	int turretAngle;
};

struct CTankActions
{
	CTankActions():x(0),y(0),baseAngle(0),turretAngle(0),fireDistance(-1), fireAngle(0) {}
	int x;
	int y;
	int baseAngle;
	int turretAngle;
	int liveDamage;
	int fireDistance;
	int fireAngle;
	int movingAngle;
	strategy strateg;
	int retreatTime;
	int targetAngle;
	std::vector<enemy> enemies;
};

extern "C"
{
	AI_API void SetCoords(int x, int y);
	AI_API void SetAngle(int angle);
	AI_API void SetTurretAngle(int angle);
	AI_API void SetCollisionStatus(bool isCollided);
	AI_API void SetLivePercent(int percent);
	AI_API void SetVisilbeEnemyCount(int count);
	AI_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent);
	AI_API int GetDirection();
	AI_API int GetRotateDirection();
	AI_API int GetRotateSpeed();
	AI_API int GetTurretRotateDirection();
	AI_API int GetTurretRotateSpeed();
	AI_API int GetFireDistance();
	AI_API void SetCoordinatesChest(int id, double x, double y);
	AI_API void SetVisibleChests(int count);
	AI_API void Update();
}