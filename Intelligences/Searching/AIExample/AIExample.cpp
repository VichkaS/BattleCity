// AIExample.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "AIExample.h"

#define _USE_MATH_DEFINES
#include <math.h>
  
CTankActions tank;

int CompareAngles(int a, int b)///���������� ����
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

double GetDistance (int x1, int x2, int y1, int y2) // �������� ����������
{
	return sqrt((float)((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)));  //���������� �� 1 �� 200
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
	tank.enemies.clear();
	tank.enemies.resize(visibleEnemies);
}

AI_API void SetEnemyProperties(int id, int x, int y, int angle, int turretAngle, int healthPoints)
{
	tank.enemies[id].x = x;
	tank.enemies[id].y = y;
	tank.enemies[id].health = healthPoints;
	tank.enemies[id].turretAngle = turretAngle;
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
	int speed = 10;

	if(tank.fireDistance != -1 && abs(CompareAngles(tank.baseAngle, tank.movingAngle)) < 10)
	{
		speed = abs(CompareAngles(tank.baseAngle, tank.movingAngle));
	}

	if (CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
	{
		return speed;
	}
	if (CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
	{
		return -speed;
	}
	if (tank.strateg == searching)
	{
		return speed;
	}
	return 0;
}

AI_API int GetTurretRotationSpeed()
{
	int speed = abs(CompareAngles(tank.turretAngle, tank.fireAngle));
	if (speed > 20)
	{
		speed = 20;
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
	if (abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < (1800 / tank.fireDistance))
	{
		return tank.fireDistance;
	}
	return -1;
}

AI_API void GetAuthorName(char *buffer, size_t buffer_size)
{
	strcpy_s(buffer, buffer_size, "������� ������ ����������");
}

AI_API void Update()
{
	tank.strateg = searching; //��������� �� ��������� 
	tank.movingAngle = tank.baseAngle;  //���� �������� ��� �� ��� � � ��������� �����
	tank.fireAngle = tank.baseAngle; //���� �������� ��� �� ��� �  � �������
	int preferedEnemy = -1;//���������� �����
	int enemyX = 0;  //���� �
	int enemyY = 0;  // ���� �
	for(unsigned int i = 0; i < tank.enemies.size(); i++)   //������� ���������� ����������� 
	{
		if ((tank.enemies[i].health <= 20))
		{
			preferedEnemy = (int)GetDistance(tank.enemies[i].x, tank.x, tank.enemies[i].y, tank.y) * tank.enemies[i].health;
			enemyX = tank.enemies[i].x;
			enemyY = tank.enemies[i].y;
			break;
		}
		if(GetDistance(tank.enemies[i].x, tank.x, tank.enemies[i].y, tank.y) * tank.enemies[i].health < preferedEnemy || preferedEnemy == -1) // ���� ���� ����� � � ���� ������ ������ ��� ����� �� ���� �� ������� ���� ���������� ������������
		{
			preferedEnemy = (int)GetDistance(tank.enemies[i].x, tank.x, tank.enemies[i].y, tank.y) * tank.enemies[i].health;
			enemyX = tank.enemies[i].x;
			enemyY = tank.enemies[i].y;
		}
	}
	if(preferedEnemy == -1)
	{
		tank.fireDistance = -1;
		return;
	} 
	else
	{
		tank.strateg = camping;
	}

	// �������� ��������� ����
	tank.fireDistance = static_cast<int>(sqrt((float)((tank.x - enemyX) * (tank.x - enemyX) + (tank.y - enemyY) * (tank.y - enemyY))) / 1);
	// ��������� ���� ���� ������� �����
	tank.fireAngle = static_cast<int>(-atan2((float)(enemyY - tank.y), (float)(tank.x - enemyX)) * 180 / M_PI - 90);
	tank.movingAngle = tank.fireAngle;
}
