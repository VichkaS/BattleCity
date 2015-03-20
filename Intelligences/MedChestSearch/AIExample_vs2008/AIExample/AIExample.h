// This class is exported from the dll_example.dll
#ifdef AIEXAMPLE_EXPORTS
#define AI_API __declspec(dllexport) 
#else
#define AI_API __declspec(dllimport) 
#endif
#include <vector>

class AI_API CAI {
public:
	CAI(void) {}
};

enum strategy
{
	searching, //Rotating until we can see something
	attacking, //Get closer to enemy
};


struct medChest
{
	medChest()
	:m_x(-1), m_y(-1)
	{

	}
	medChest(double x, double y)
	:m_x(x), m_y(y)
	{

	}
	double m_x;
	double m_y;
};

int m_countMed = 0;
medChest allMedChests[100];

struct CTankActions
{
	CTankActions():x(0),y(0),baseAngle(0),turretAngle(0),fireDistance(-1), fireAngle(0),livePercent(100) {}
	int x;
	int y;
	int baseAngle;
	int turretAngle;
	int livePercent;
	int liveDamage;
	bool isCollided;
	int fireDistance;
	int fireAngle;
	int movingAngle;
	strategy strateg;
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
	AI_API int  GetDirection();
	AI_API int  GetRotateDirection();
	AI_API int  GetRotateSpeed();
	AI_API int  GetTurretRotateDirection();
	AI_API int  GetTurretRotateSpeed();
	AI_API int  GetFireDistance();
	AI_API void SetVisibleChests(int count);
	AI_API void SetCoordinatesChest(int id, double x, double y);
	AI_API void Update();
}