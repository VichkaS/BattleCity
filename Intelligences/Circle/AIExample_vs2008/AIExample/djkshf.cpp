﻿
#include "stdafx.h"
#include "AIExample.h"
#include "Al_handle.h"
#include "assert.h" 
#define _USE_MATH_DEFINES

#include <math.h>

#define NO_FIRE = -1;
#define TIME_TO_RETREAT = 30;
#define RETIREMENT = 1;  
#define ATTACK = 2;
#define CAMPING = 3;

CTankActions tank;


extern "C"
{
	AIEXAMPLE_API void SetCoords(int x, int y)//устанавливаем координаты танка 
	{
		tank.x = x;
		tank.y = y;
	}
	AIEXAMPLE_API void SetAngle(int angle)//угол поворота нижней части
	{
		tank.baseAngle = angle;
	}
	AIEXAMPLE_API void SetTurretAngle(int angle)//угол поворота башни танка
	{
		tank.turretAngle = angle;
	}
	AIEXAMPLE_API void SetCollisionStatus(bool isCollided)//установка статуса врезался во что нибудь или нет
	{
		tank.isCollided = isCollided;
	}
	AIEXAMPLE_API void SetLivePercent(int percent) //установить число здоровья 
	{
		if(tank.liveDamage > 0)
		{
			--tank.liveDamage;
		}
		tank.liveDamage += tank.livePercent - percent;
		tank.livePercent = percent; 

	}
	AIEXAMPLE_API void SetVisilbeEnemyCount(int count) //устанавливает число видимых танков
	{
		tank.enemies.clear();
		tank.enemies.resize(count);
	}
	AIEXAMPLE_API void SetEnemyProteries(int enemyID, int x, int y, int angle, int turretAngle, int livePercent) //устанавливает свойство танка с номером 
	{
		tank.enemies[enemyID].x = x;
		tank.enemies[enemyID].y = y;
		tank.enemies[enemyID].health = livePercent;
		tank.enemies[enemyID].turretAngle = turretAngle;
	}
	AIEXAMPLE_API int GetDirection()//направление движения
	{
		if(tank.strateg == attacking)
		{
			return 1;
		}
		if(tank.strateg == retreating)
		{
			return -1;
		}
		return 0;
	}
	AIEXAMPLE_API int GetRotateDirection()//поворот нижней части
	{
		if(CompareAngles(tank.baseAngle, tank.movingAngle) > 0)
		{
			return 1;
		}
		if(CompareAngles(tank.baseAngle, tank.movingAngle) < 0)
		{
			return -1;
		}
		if(tank.strateg == searching)//поиск всегда по часовой стрелке
		{
			return 1;
		}
		return 0;
	}
	AIEXAMPLE_API int GetRotateSpeed()//скорость повворота нижней части
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
	AIEXAMPLE_API int GetTurretRotateDirection() //направление поворота башни
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
	AIEXAMPLE_API int GetTurretRotateSpeed() // скорость поворота башни
	{
		if(abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < 20)
		{
			return abs(CompareAngles(tank.turretAngle, tank.fireAngle));
		}
		return 20;
	}
	AIEXAMPLE_API int GetFireDistance()//запрашивает дальность выстрела
	{
		if(abs(CompareAngles(tank.turretAngle, tank.fireAngle)) < (1800 / tank.fireDistance))
		{
			return tank.fireDistance;
		}
		return -1;  //не стрелять!!!!
	}

	

	void Retreat() // отступление
	{
		double newX = tank.x - 100 * sin(tank.baseAngle * M_PI / 180);
		double newY = tank.y + 100 * cos(tank.baseAngle * M_PI / 180);
		int rotation = 0;
		if(tank.isCollided)//если врезался
		{
			rotation = 10;
		}
		else
		{
			rotation = getRotate(newX,newY);
		}
		tank.movingAngle = tank.baseAngle - rotation;
	}

	AIEXAMPLE_API void Update() //d:\РГР\AIExample_vs2008\AIExample\AIExample.cpp
	{
		tank.strateg = searching; //стратегия по умолчанию 
		tank.movingAngle = tank.baseAngle;  //угол движения тот же что и у положения танка
		tank.fireAngle = tank.baseAngle; //угол стрельбы тот же что и  у корпуса
		int retreatRatio = -tank.livePercent / 10 + 10 * tank.isCollided + 2 * tank.liveDamage;   //состояние отступление
		int preferedEnemy = -1;//приориотет танка
		int countEnemy = 0; // кол-во врагов
		int enemyX = 0;  //враг х
		int enemyY = 0;  // враг у
		int action = 0 ;

		assert(tank.enemies.size() >= 0);
		assert(tank.x > 0 && tank.y > 0);

		for(unsigned int i = 0; i < tank.enemies.size(); i++)   //видимые противники перечисляем 
		{
			assert(tank.enemies[i].x > 0 && tank.enemies[i].y  > 0);
			assert((tank.enemies[i].health >= 0) &&(tank.livePercent >= 0));

			if(GetDistance(tank.enemies[i].x, tank.x, tank.enemies[i].y, tank.y) * (1/tank.enemies[i].health) < preferedEnemy || preferedEnemy == NO_FIRE) // если танк ближе и у него меньше жизней или врага не было то текущий враг становится приоритетным
			{
				preferedEnemy = (int)GetDistance(tank.enemies[i].x, tank.x, tank.enemies[i].y, tank.y) * tank.enemies[i].health;
				enemyX = tank.enemies[i].x;
				enemyY = tank.enemies[i].y;
			}
			//
			if(abs(CompareAngles(tank.enemies[i].turretAngle, 180 - tank.turretAngle)) < 45)  //если угол меньше 45 градусов
			{
				countEnemy++;
				retreatRatio += 5; //соотношение жизней
			}
			else
			{
				retreatRatio -= 5;
			}
		}

		action = getAction(retreatRatio, countEnemy, preferedEnemy, tank.x, enemyX, tank.y, enemyY);
		if(action == RETIREMENT)
		{
			onRetreating (TIME_TO_RETREAT, preferedEnemy, &tank)
		}
		else if(action == ATTACK)
		{
			onAttacking(&tank);
		}
		else if(action == CAMPING)
		{
			onCamping(&tank);
		}
	
		if(tank.retreatTime > 0)
		{
			onDecreaseRetreate(&tank); //отступаем
		}
		if(tank.strateg == retreating)
		{
			Retreat();
		}
		if(preferedEnemy == NO_FIRE)
		{
			onNotShoot(&tank, NO_FIRE);
			return;
		}
		
		onFire(&tank, enemyX, enemyY);
		if(tank.strateg == attacking || tank.strateg == camping)
		{
			onMoveAngle(&tank);
		}
	}
}

