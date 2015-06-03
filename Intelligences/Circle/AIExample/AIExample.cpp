#include "stdafx.h"
#include "AIExample.h"

#define _USE_MATH_DEFINES
#include <math.h>

#define TANK_LENGHT 640
#define TANK_WIDHT 480
#define MIN_X 100
#define MAX_X 540
#define MIN_Y 100
#define MAX_Y 380

#define MAX_ROTATE_SPEED 10
#define MAX_TURRET_ROTATE_SPEED 20
#define NO_FIRE  -1

CTankActions tank;

AIEXAMPLE_API void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided)
{
	tank.x = x;
	tank.y = y;
	tank.baseAngle = angle;
	tank.turretAngle = turretAngle;
}

AIEXAMPLE_API void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses)
{
}

AIEXAMPLE_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints)
{
}

AIEXAMPLE_API void SetBonusCoord(int id, int x, int y)
{
}

AIEXAMPLE_API void SetAntibonusCoord(int id, int x, int y)
{
}

AIEXAMPLE_API int GetDirection()
{
	return 1;
}

AIEXAMPLE_API int GetRotationSpeed()
{
	if (CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
	{
		return MAX_ROTATE_SPEED;
	}
	else if (CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
	{
		return -MAX_ROTATE_SPEED;
	}
	else
	{
		return 0;
	}
}

AIEXAMPLE_API int GetTurretRotationSpeed()
{
	int dir = 0;

	if (CompareAngles(tank.turretAngle, tank.fireAngle) > 0)
	{
		dir = 1;
	}
	else if (CompareAngles(tank.turretAngle, tank.fireAngle) < 0)
	{
		dir = -1;
	}

	if (abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < MAX_TURRET_ROTATE_SPEED)
	{
		return abs(CompareAngles(tank.turretAngle, tank.fireAngle)) * dir;
	}
	else
	{
		return MAX_TURRET_ROTATE_SPEED * dir;
	}
}

AIEXAMPLE_API int GetFireDistance()
{
	return NO_FIRE;
}

AIEXAMPLE_API void GetAuthorName(char *buffer, size_t buffer_size)
{
	strcpy_s(buffer, buffer_size, "Круговой Олег Викторович");
}

AIEXAMPLE_API void Update()
{
	tank.movingAngle = tank.baseAngle; 
	tank.fireAngle = tank.baseAngle;
		
	const int centrX = TANK_LENGHT / 2;
	const int centrY = TANK_WIDHT / 2;

	tank.fireAngle = static_cast<int>(-atan2((float)(centrY - tank.y), (float)(tank.x - centrX)) * 180 /M_PI);
	tank.movingAngle = tank.fireAngle;
}

//сравниваем углы
int CompareAngles(int a, int b)
{
    while (a < 0)
    {
		a += 360;
    }
	while (b < 0)
    {
		b += 360;
    }
	int angle = b % 360 - a % 360;
	if(angle > 180)
	{
		angle -= 360;
	}
	if(angle < -180)
	{
		angle += 360;
	}
	return angle;
}
