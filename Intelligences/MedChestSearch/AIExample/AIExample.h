#pragma once

#include <vector>

#ifdef AIEXAMPLE_EXPORTS
#define AI_API __declspec(dllexport) 
#else
#define AI_API __declspec(dllimport) 
#endif

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
	AI_API void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided);
	AI_API void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses);
	AI_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints);
	AI_API void SetBonusCoord(int id, int x, int y);
	AI_API void SetAntibonusCoord(int id, int x, int y);
	AI_API int GetDirection();
	AI_API int GetRotationSpeed();
	AI_API int GetTurretRotationSpeed();
	AI_API int GetFireDistance();
	AI_API void GetAuthorName(char *buffer, size_t buffer_size);
	AI_API void Update();
}
