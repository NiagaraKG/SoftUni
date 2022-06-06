#ifndef MAKE_COMPANY_H
#define MAKE_COMPANY_H

#include "Company.h"

#include <vector>
#include <string>
#include <sstream>
#include <utility>
#include <memory>

using namespace std;

shared_ptr<Company> makeCompany(vector<string> input)
{
	istringstream In(input[0]);
	int ID;
	In >> ID;
	string Name;
	Name = input[1];
	vector<std::pair<char, char> > Employees;
	for(int i = 2; i < input.size(); i++)
	{
		char first = (input[i])[0];
		char second = (input[i])[1];
		Employees.push_back(make_pair(first, second));
	}
	shared_ptr<Company> c (new Company(ID, Name, Employees));
	return c;
}

#endif // !MAKE_COMPANY_H
