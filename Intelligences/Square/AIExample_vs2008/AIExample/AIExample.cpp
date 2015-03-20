#include "stdafx.h"
#include "AIExample.h"

#define USE_MATH_DEFINES
#include <math.h>


#define MAX_ROTATE_SPEED 10
#define MAX_TURRET_ROTATE_SPEED 20
#define NO_FIRE  -1
#define MIN_X 100
#define MAX_X 540
#define MIN_Y 100
#define MAX_Y 380


CTankActions tank;

int CompareAngles(int a, int b);
int getAngle(int x, int y, int angle);


extern "C"
{
	AIEXAMPLE_API void SetCoords(int x, int y)
	{
		tank.x = x;
		tank.y = y;
	}
	AIEXAMPLE_API void SetAngle(int angle)
	{
		tank.baseAngle = angle;
	}
	AIEXAMPLE_API void SetTurretAngle(int angle)
	{
		tank.turretAngle = angle;
	}
	AIEXAMPLE_API void SetCollisionStatus(bool isCollided)
	{
	}
	AIEXAMPLE_API void SetLivePercent(int percent)
	{
	}
	AIEXAMPLE_API void SetVisilbeEnemyCount(int count) 
	{
	}
	AIEXAMPLE_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent) 
	{
	}
	AIEXAMPLE_API void SetVisibleChests(int count)
	{
	}
	AIEXAMPLE_API void SetCoordinatesChest(int id, double x, double y)
	{
	}
	AIEXAMPLE_API int GetDirection()
	{
		return 1;
	}
	AIEXAMPLE_API int GetRotateDirection()
	{
		if(CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
		{
			return 1;
		}
		if(CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
		{
			return -1;
		}
		return 0;
	}
	AIEXAMPLE_API int GetRotateSpeed()
	{
		return MAX_ROTATE_SPEED;
	}
	AIEXAMPLE_API int GetTurretRotateDirection()
	{
		if(CompareAngles(tank.turretAngle, tank.fireAngle) > 0)
		{
			return 1;
		}
		if(CompareAngles(tank.turretAngle, tank.fireAngle) < 0)
		{
			return -1;
		}
		return 0;
	}
	AIEXAMPLE_API int GetTurretRotateSpeed() 
	{
		if(abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < MAX_TURRET_ROTATE_SPEED)
		{
			return abs(CompareAngles(tank.turretAngle, tank.fireAngle));
		}
		return MAX_TURRET_ROTATE_SPEED;
	}
	AIEXAMPLE_API int GetFireDistance()
	{
		return NO_FIRE;
	}
	AIEXAMPLE_API void Update() 
	{
		tank.movingAngle = tank.baseAngle; 
		tank.fireAngle = tank.baseAngle;

		int angle = getAngle(tank.x, tank.y, tank.baseAngle);

		tank.movingAngle = angle;
		tank.fireAngle = tank.movingAngle;
	}
}

int getAngle(int x, int y, int angle)
{
	if(x < MIN_X)
	{
		if (y > MAX_Y)
		{
			return 90;
		}
		else
		{
			return 180;
		}
	}
	else if(x > MAX_X)
	{
		if (y < MIN_Y)
		{
			return 270;
		}
		else
		{
			return 0;
		}
	}
	else if (y < MIN_Y)
	{
		return 270;
	}
	else if (y > MAX_Y)
	{
		return 90;
	}
	else
	{
		return angle;
	}
}

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
