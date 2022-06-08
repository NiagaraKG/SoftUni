#ifndef PARSE_COMPANIES_H
#define PARSE_COMPANIES_H

#include "Company.h"

#include <string>
#include <sstream>
#include <vector>
#include <utility>
#include <algorithm>

using namespace std;

Company* parseUniqueCompanies(string input, int& numCompanies, string By(const Company& c))
{
	vector<string> StrBy;
	vector<Company> Companies;
	numCompanies = 0;
	istringstream In(input);
	int ID;
	string name;
	while (In >> ID)
	{
		In >> name;
		Company c(ID, name);
		string by = By(c);
		if (find(StrBy.begin(), StrBy.end(), by) == StrBy.end())
		{
			StrBy.push_back(by);
			Companies.push_back(c);
			numCompanies++;
		}
	}
	Company* Arr = new Company[numCompanies];
	int i = 0;
	for (Company c : Companies)
	{
		Arr[i] = c;
		i++;
	}
	return Arr;
}

#endif // !PARSE_COMPANIES_H
