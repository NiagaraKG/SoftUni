#ifndef COMPANY_H
#define COMPANY_H

#include "HasInfo.h"
#include "HasId.h"

#include <string>
#include <vector>
#include <sstream>
#include <istream>

class Company : public HasInfo, public HasId
{
public:
	int id;
	std::string name;
	std::vector<std::pair<char, char> > employees;

	Company();

	Company(int id, std::string name, std::vector<std::pair<char, char> > employees);

	 int getId() const;

	std::string getName() const;

	std::vector<std::pair<char, char> > getEmployees() const;

	std::string getInfo() const;

	friend std::istream& operator>>(std::istream& stream, Company& c);
	friend std::ostream& operator<<(std::ostream& stream, const Company& c);
};


#endif