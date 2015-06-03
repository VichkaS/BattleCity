// AIExample.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "AIExample.h"
#define _USE_MATH_DEFINES

#include <math.h>

CTankActions tank;

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

double GetDistance(int x1, int x2, int y1, int y2)
{
	return sqrt(static_cast<double>((x1-x2)*(x1-x2)) + (y1-y2)*(y1-y2));
}

AI_API void SetStatus(int x, int y, int angle, int turretAngle, int healthPoints, bool isCollided)
{
	tank.x = x;
	tank.y = y;
	tank.baseAngle = angle;
	tank.turretAngle = turretAngle;
	tank.isCollided = isCollided;

	if(tank.liveDamage > 0)
	{
		--tank.liveDamage;
	}
	tank.liveDamage += tank.livePercent - healthPoints;
	tank.livePercent = healthPoints; 
}

AI_API void SetObjectCount(int visibleEnemies, int bonuses, int antibonuses)
{
	if (bonuses >= 0 && bonuses < 100)
	{
		m_countMed = bonuses;
		return;
	}
	m_countMed = 0;
}

AI_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints)
{
}

AI_API void SetBonusCoord(int id, int x, int y)
{
	if (id <= 99)
	{
		medChest medTemp(x, y);
		allMedChests[id] = medTemp;
	}
}

AI_API void SetAntibonusCoord(int id, int x, int y)
{
}

AI_API int GetDirection()
{
	if (tank.strateg == attacking)
	{
		return 1;
	}
 
	return 0;
}

AI_API int GetRotationSpeed()
{
	int dir = 0;

	if (CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
	{
		dir = 1;
	}
	else if (CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
	{
		dir = -1;
	}
	else if (tank.strateg == searching)
	{
		dir = 1;
	}

	if (tank.strateg == searching)
	{
		return dir*10;
	}
	if (tank.fireDistance != -1 && abs(CompareAngles(tank.baseAngle, tank.movingAngle)) < 10)
	{
		return dir*abs(CompareAngles(tank.baseAngle, tank.movingAngle));
	}

	return dir*10;
}

AI_API int GetTurretRotationSpeed()
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
	
	if (abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < 20)
	{
		return dir*abs(CompareAngles(tank.turretAngle, tank.fireAngle));
	}

	return dir*20;
}

AI_API int GetFireDistance()
{
	return -1;
}

AI_API void GetAuthorName(char *buffer, size_t buffer_size)
{
	strcpy_s(buffer, buffer_size, "Çהמנמגüוג Âכאהטלטנ Îכודמגטק");
}

AI_API void Update()
{
	tank.strateg = searching;
	tank.movingAngle = tank.baseAngle;
	tank.fireAngle = tank.baseAngle;

	double medChestX = 0;
	double medChestY = 0;

	if (!m_countMed)
	{
		tank.strateg = searching;
		return;
	}
	else
	{ 
		medChest medFirst = allMedChests[0];
		double distanceMin = GetDistance((int)allMedChests[0].m_x, (int)tank.x, (int)allMedChests[0].m_y, (int)tank.y);

		for(int i = 0; i < m_countMed; ++i)
		{
			if(distanceMin > GetDistance((int)allMedChests[i].m_x, (int)tank.x, (int)allMedChests[i].m_y, (int)tank.y))
			{
				distanceMin = GetDistance((int)allMedChests[i].m_x, (int)tank.x, (int)allMedChests[i].m_y, (int)tank.y);
				medFirst = allMedChests[i];
			}
		}

		medChestX = (int)medFirst.m_x;
		medChestY =(int)medFirst.m_y;
		tank.fireAngle = static_cast<int>(-atan2(static_cast<double>(medChestY - tank.y), static_cast<double>(tank.x - medChestX)) * 180 / M_PI - 90);
		tank.movingAngle = tank.fireAngle;
		tank.strateg = attacking;
	}
}
