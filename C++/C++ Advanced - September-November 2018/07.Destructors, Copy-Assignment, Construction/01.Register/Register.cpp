#include "Register.h"
#include "Company.h"

#include <string>

Register::Register(size_t numCompanies)
{
	numAdded = 0;
	this->companiesArray = new Company[numCompanies];
}

void Register::add(const Company& c)
{
	this->companiesArray[numAdded] = c;
	numAdded++;
}

Company Register::get(int companyId) const
{
	
	for (size_t i = 0; i < numAdded; i++)
	{
		if (companiesArray[i].getId() == companyId)
		{
			return companiesArray[i];
		}
	}
}

Register::~Register()
{
	delete[] this->companiesArray;
	this->companiesArray = nullptr;
}