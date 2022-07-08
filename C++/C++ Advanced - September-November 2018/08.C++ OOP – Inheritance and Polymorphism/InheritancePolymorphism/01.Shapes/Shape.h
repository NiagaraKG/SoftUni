#ifndef SHAPE_H
#define SHAPE_H

#include "Vector2D.h"

class Shape
{
protected:
	double area;
	Vector2D center;

	Shape() : center(*(new Vector2D{0, 0})) {}

	Shape(Vector2D center) : area(0), center(center) {}

public:
	Vector2D getCenter()
	{
		return this->center;
	}

	double getArea()
	{
		return this->area;
	}

};

#endif // !SHAPE_H
