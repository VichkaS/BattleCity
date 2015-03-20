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
		tank.isCollided = isCollided;
	}

	AI_API void SetLivePercent(int percent) 
	{
		if(tank.liveDamage > 0)
		{
			--tank.liveDamage;
		}
		tank.liveDamage += tank.livePercent - percent;
		tank.livePercent = percent; 
	}

	AI_API void SetVisilbeEnemyCount(int count) 
	{
	}

	AI_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent)
	{
	}
	AI_API int GetDirection()
	{
		if(tank.strateg == attacking)
		{
			return 1;
		}
 
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
		if(tank.strateg == searching)
		{
			return 1;
		}
		return 0;
	}
	AI_API int GetRotateSpeed()
	{
		if(tank.strateg == searching)
		{
			return 10;
		}
		if(tank.fireDistance != -1 && abs(CompareAngles(tank.baseAngle, tank.movingAngle)) < 10)
		{
			return abs(CompareAngles(tank.baseAngle, tank.movingAngle));
		}
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
		return -1;
	}

	double GetDistance (int x1, int x2, int y1, int y2)
	{
		return sqrt(static_cast<double>((x1-x2)*(x1-x2)) + (y1-y2)*(y1-y2));
	}

	AI_API void SetVisibleChests(int count)
	{
		if (count >= 0 && count < 100)
		{
			m_countMed = count;
			return;
		}
		m_countMed = 0;
	}
	AI_API void SetCoordinatesChest(int id, double x, double y)
	{
		if (id <= 99)
		{
			medChest medTemp(x, y);
			allMedChests[id] = medTemp;
		}
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
		}else
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
			tank.fireAngle = -atan2(static_cast<double>(medChestY - tank.y), static_cast<double>(tank.x - medChestX)) * 180 / M_PI - 90;
			tank.movingAngle = tank.fireAngle;
			tank.strateg = attacking;
		 }
	}
}
