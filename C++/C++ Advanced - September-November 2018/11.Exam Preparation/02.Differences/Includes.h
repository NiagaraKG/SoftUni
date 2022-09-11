#ifndef INCLUDES_H
#define INCLUDES_H

#include "City.h"

#include <vector>
#include <iostream>
#include <utility>
#include <istream>
#include <ostream>
#include <string>
#include <algorithm>

class CityDiff
{
	City a;
	City b;
public:
	CityDiff(City a, City b) : a(a), b(b) {}

	friend std::ostream& operator<< (std::ostream& Out, const CityDiff& d);
};

std::istream& operator>> (std::istream& In, City& city)
{
	unsigned int year;
	std::string name;
	size_t population;
	In >> name >> population >> year;
	City c(year, name, population);
	city = c;
	return In;
}

std::ostream& operator<< (std::ostream& Out, const CityDiff& d)
{
	if (d.a.getName() == d.b.getName())
	{
		Out << d.a.getName() << " (" << d.a.getCensusYear() << " vs. " << d.b.getCensusYear() << ")";
	}
	else
	{
		Out << d.a.getName() << " (" << d.a.getCensusYear() << ") vs. " << d.b.getName() << " (" << d.b.getCensusYear() << ")";
	}
	Out << std::endl << "population: ";
	auto diff = std::max(d.a.getPopulation(), d.b.getPopulation()) - std::min(d.a.getPopulation(), d.b.getPopulation());
	if (d.a.getPopulation() >= d.b.getPopulation()) { Out << '+'; }
	else { Out << '-'; }
	Out << diff << std::endl;
	return Out;
}

CityDiff operator- (City a, City b)
{
	return CityDiff(a, b);
}

#endif
