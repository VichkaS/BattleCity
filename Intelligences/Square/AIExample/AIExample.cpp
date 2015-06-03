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

int GetAngle(int x, int y, int angle)
{
	if (x < MIN_X)
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
	if (angle > 180)
	{
		angle -= 360;
	}
	if (angle < -180)
	{
		angle += 360;
	}
	return angle;
}

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
	if (CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
	{
		return -MAX_ROTATE_SPEED;
	}
	return 0;
}

AIEXAMPLE_API int GetTurretRotationSpeed()
{
	int speed;

	if (abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < MAX_TURRET_ROTATE_SPEED)
	{
		speed = abs(CompareAngles(tank.turretAngle, tank.fireAngle));
	}
	else
	{
		speed = MAX_TURRET_ROTATE_SPEED;
	}

	if (CompareAngles(tank.turretAngle, tank.fireAngle) > 0)
	{
		return speed;
	}
	if (CompareAngles(tank.turretAngle, tank.fireAngle) < 0)
	{
		return -speed;
	}
	return 0;
}

AIEXAMPLE_API int GetFireDistance()
{
	return NO_FIRE;
}

AIEXAMPLE_API void GetAuthorName(char *buffer, size_t buffer_size)
{
	strcpy_s(buffer, buffer_size, "Квадратов Михаил Александров");
}

AIEXAMPLE_API void Update()
{
	tank.movingAngle = tank.baseAngle; 
	tank.fireAngle = tank.baseAngle;

	int angle = GetAngle(tank.x, tank.y, tank.baseAngle);

	tank.movingAngle = angle;
	tank.fireAngle = tank.movingAngle;
}
