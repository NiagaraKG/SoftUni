#ifndef SMALL_FILTER
#define SMALL_FILTER

#include "Filter.h"

class SmallFilter : public Filter
{
public:
	virtual bool shouldFilterOut(char symbol) const
	{
		if (symbol >= 'a' && symbol <= 'z')
		{
			return true;
		}
		return false;
	}
};

#endif
