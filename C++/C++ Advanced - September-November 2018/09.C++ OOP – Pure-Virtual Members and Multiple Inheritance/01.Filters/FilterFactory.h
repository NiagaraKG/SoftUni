#ifndef FILTER_FACTORY
#define FILTER_FACTORY

#include <memory>
#include <string>
#include <memory>

#include "Filter.h"
#include "CapitalFilter.h"
#include "SmallFilter.h"
#include "DigitFilter.h"

class FilterFactory
{
public:
	Filter*	buildFilter(std::string definition) const
	{
		if (definition == "A-Z")
		{
			CapitalFilter* cptr(new CapitalFilter);
			return cptr;
		}
		else if (definition == "a-z")
		{
			SmallFilter* sptr(new SmallFilter);
			return sptr;
		}
		else
		{
			DigitFilter* dptr(new DigitFilter);
			return dptr;
		}
	}
};

#endif
