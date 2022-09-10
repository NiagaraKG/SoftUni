#ifndef CITY_UTILS_H
#define CITY_UTILS_H

#include "City.h"

#include <map>
#include <string>
#include <cstdlib>

const City* initCity (const std::string& name, size_t population)
{
	return new City{name, population};
}

std::map<size_t, const City*> groupByPopulation(const std::vector<const City*>& cities, size_t& totalPopulation)
{
	totalPopulation = 0;
	std::map<size_t, const City*> byPopulation;
	for (auto city : cities)
	{
		byPopulation[city->getPopulation()] = city;
		totalPopulation += city->getPopulation();
	}
	return byPopulation;
}

#endif
