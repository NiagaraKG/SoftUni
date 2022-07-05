#ifndef ARRAY_OF_POINTERS_H
#define ARRAY_OF_POINTERS_H

#include "Company.h"

#include <vector>

class ArrayOfPointers
{
	std::vector<Company*> companies;
public:
	ArrayOfPointers() {};

	void add(Company* c)
	{
		companies.push_back(c);
	}

	size_t getSize()
	{
		return this->companies.size();
	}

	Company* get(size_t index)
	{
		return companies[index];
	}
	
	~ArrayOfPointers()
	{
		for (auto c : companies)
		{
			delete c;
		}
	}
};

#endif
