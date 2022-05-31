#ifndef COMPANYMEMORYUTILS_H
#define COMPANYMEMORYUTILS_H

#include <vector>
#include <string>
#include <utility>

using namespace std;

#include "Company.h"

vector<Company> readCompaniesFromMemory(unsigned char* memory, int numCompanies)
{
	vector<Company> companies;
	int i = 0;
	while (numCompanies != 0)
	{
		int ID = memory[i];
		string Name;
		i++;
		while (memory[i] != '\0')
		{
			Name += memory[i];
			i++;
		}
		i++;
		int numEmployees = memory[i];
		vector<std::pair<char, char> > Employees;
		for (int e = 0; e < numEmployees; e++)
		{
			pair<char, char> employee;
			i++;
			employee.first = memory[i];
			i++;
			employee.second = memory[i];
			Employees.push_back(employee);
		}
		i++;
		companies.push_back(Company(ID, Name, Employees));
		numCompanies--;
	}
	return companies;
}
#endif // !COMPANYMEMORYUTILS_H
