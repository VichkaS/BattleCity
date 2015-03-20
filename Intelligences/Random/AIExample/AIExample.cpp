// AIExample.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "AIExample.h"
#define _USE_MATH_DEFINES

#include <math.h>
#include <time.h>
#include <stdio.h>
#include <stdlib.h>

CTankActions tank;

int CompareAngles(int a, int b)///сравниваем углы
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

double GetDistance (int x1, int x2, int y1, int y2) // получить расстояние
	{
		return sqrt((float)((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)));  //расстояние от 1 до 200
	}


extern "C"
{
	AI_API void SetCoords(int x, int y)
	{
		tank.x = x;
		tank.y = y;
	}
	AI_API void SetAngle(int angle)
	{
		tank.baseAngle = angle;
	}
	AI_API void SetTurretAngle(int angle)
	{
		tank.turretAngle = angle;
	}
	AI_API void SetCollisionStatus(bool isCollided)
	{
	}

	AI_API void SetLivePercent(int percent) 
	{
	}

	AI_API void SetVisilbeEnemyCount(int count) 
	{
	}
	AI_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent)
	{
	}

	AI_API int GetDirection()
	{
		return 0;
	}
	AI_API int GetRotateDirection()
	{
		if(CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
		{
			return 1;
		}
		if(CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
		{
			return -1;
		}
		return 1;
	}
	AI_API int GetRotateSpeed()
	{
		return 10;
	}
	AI_API int GetTurretRotateDirection()
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
	AI_API int GetTurretRotateSpeed()
	{
		if(abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < 20)
		{
			return abs(CompareAngles(tank.turretAngle, tank.fireAngle));
		}
		return 20;
	}
	AI_API int GetFireDistance()
	{
		return 120;
	}

	AI_API void SetVisibleChests(int count)
	{
	}

	AI_API void SetCoordinatesChest(int id, double x, double y)
	{
	}


	AI_API void Update()
	{
		tank.movingAngle = tank.baseAngle;  //угол движения тот же что и у положения танка
		tank.fireAngle = tank.baseAngle; //угол стрельбы тот же что и  у корпуса
	}
}

