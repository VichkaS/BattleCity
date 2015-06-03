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

double GetDistance(int x1, int x2, int y1, int y2) // получить расстояние
{
	return sqrt((float)((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)));  //расстояние от 1 до 200
}

AI_API void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided)
{
	tank.x = x;
	tank.y = y;
	tank.baseAngle = angle;
	tank.turretAngle = turretAngle;
}

AI_API void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses)
{
}

AI_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints)
{
}

AI_API void SetBonusCoord(int id, int x, int y)
{
}

AI_API void SetAntibonusCoord(int id, int x, int y)
{
}

AI_API int GetDirection()
{
	return 0;
}

AI_API int GetRotationSpeed()
{
	if (CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
	{
		return 10;
	}
	if (CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
	{
		return -10;
	}
	return 10;
}

AI_API int GetTurretRotationSpeed()
{
	int speed = 20;

	if (abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < 20)
	{
		speed = abs(CompareAngles(tank.turretAngle, tank.fireAngle));
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

AI_API int GetFireDistance()
{
	return 120;
}

AI_API void GetAuthorName(char *buffer, size_t buffer_size)
{
	strcpy_s(buffer, buffer_size, "Случайнов Кирилл Дмитрович");
}

AI_API void Update()
{
	tank.movingAngle = tank.baseAngle;  //угол движения тот же что и у положения танка
	tank.fireAngle = tank.baseAngle; //угол стрельбы тот же что и  у корпуса
}
