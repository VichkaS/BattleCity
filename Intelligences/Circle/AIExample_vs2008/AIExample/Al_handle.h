#ifndef AL_HANDLE_H


#define _USE_MATH_DEFINES

#include <math.h>
#include <stdio.h>

double GetDistance (int x1, int x2, int y1, int y2); // получить расстояние
int CompareAngles(int a, int b);///сравниваем углы
int getRotate(int x,int y);
int getAction(int tankX, int enemyX, int tankY,int enemyY);
#endif