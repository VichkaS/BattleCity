#include "stdafx.h"
#include "AIExample.h"
#include "Al_handle.h"
#define _USE_MATH_DEFINES

#include <math.h>

#define TANK_LENGHT 100
#define TANK_WIDTH 100
#define MAX_ROTATE_ANGLE 10



void onAttacking(CTankActions *tank, int enemyX, int enemyY)
{
	tank->strateg = attacking;
	tank->fireAngle = -atan2((float)(enemyY - tank->y), (float)(tank->x - enemyX)) * 180 /M_PI;///вычислчем угол огня ведения танка
	tank->movingAngle = tank->fireAngle;
}
