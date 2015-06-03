#pragma once

#include <vector>

// This class is exported from the dll_example.dll
#ifdef AIEXAMPLE_EXPORTS
#define AI_API __declspec(dllexport) 
#else
#define AI_API __declspec(dllimport) 
#endif

enum strategy
{
	searching, //Rotating until we can see something
	camping //Stay and shoot
};

struct enemy
{
	int x;
	int y;
};

struct CTankActions
{
	CTankActions():x(0),y(0),baseAngle(0),turretAngle(0),fireDistance(-1), fireAngle(0) {}
	int x;
	int y;
	int baseAngle;
	int turretAngle;
	int fireDistance;
	int fireAngle;
	int movingAngle;
	strategy strateg;
	std::vector<enemy> enemies;
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
