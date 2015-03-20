#include "Al_handle.h"

#include "stdafx.h"
#include <math.h>


#define RETIREMENT   1
#define ATTACK   2
#define CAMPING   3
#define NOT_SHOOT 4
#define NO_FIRE   -1
#define MIN_DISTANCE_FOR_ATTACK 400
#define MIN_FEAR_NUMBER 10
#define ENEMIES_TO_FEAR 1
#define END_TIME_OF_RETIREMENT 0
#define ROTATE_DIFFERENCE 5
#define MIN_X 100
#define MAX_X 540
#define MIN_Y 100
#define MAX_Y 380

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
		return sqrt((float)((x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)));  
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
