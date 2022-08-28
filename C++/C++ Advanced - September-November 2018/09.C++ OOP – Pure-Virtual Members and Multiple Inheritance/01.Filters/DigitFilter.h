#ifndef DIGIT_FILTER
#define DIGIT_FILTER

#include "Filter.h"

class DigitFilter : public Filter
{
public:
	virtual bool shouldFilterOut(char symbol) const
	{
		if ((symbol-'0') >= 0 && (symbol - '0') <= 9)
		{
			return true;
		}
		return false;
	}
};

#endif