#ifndef CAPITAL_FILTER
#define CAPITAL_FILTER

#include "Filter.h"

class CapitalFilter : public Filter
{
public:
	virtual bool shouldFilterOut(char symbol) const
	{
		if (symbol >= 'A' && symbol <= 'Z')
		{
			return true;
		}
		return false;
	}
};

#endif
