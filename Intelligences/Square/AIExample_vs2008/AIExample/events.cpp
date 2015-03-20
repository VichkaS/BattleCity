#include "stdafx.h"
#include "AIExample.h"
#include "Al_handle.h"
#define _USE_MATH_DEFINES

#include <math.h>

#define TANK_LENGHT 100
#define TANK_WIDTH 100
#define MAX_ROTATE_ANGLE 10



void onAttacking(CTankActions *tank, int angle)
{
	tank->strateg = attacking;
	tank->movingAngle = angle;
	tank->fireAngle = tank->movingAngle;

}
