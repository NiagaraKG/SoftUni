#ifndef ORDERED_INSERTER_H
#define ORDERED_INSERTER_H

#include "Company.h"
#include <vector>
#include <map>
#include <algorithm>

using namespace std;

class OrderedInserter
{
public:
	vector<const Company*>& companies;
public:
	void insert(const Company* c)
	{
		map<int, const Company*> sorted_companies;
		while (!companies.empty())
		{
			int ID = companies[0]->getId();

			sorted_companies.insert(make_pair(ID, companies[0]));
			companies.erase(companies.begin());
		}
		int Id = c->getId();
		sorted_companies.insert(make_pair(Id, c));
		while (!sorted_companies.empty())
		{
			companies.push_back(sorted_companies.begin()->second);
			sorted_companies.erase(sorted_companies.begin());
		}
	}
};

#endif // !ORDERED_INSERTER_H
