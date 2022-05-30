#ifndef PROFIT_REPORT_H
#define PROFIT_REPORT_H

#include "Company.h"
#include "ProfitCalculator.h"
#include <string>
#include <map>

using namespace std;

string getProfitReport(Company* from, Company* to, map<int, ProfitCalculator> profitCalculatorsByCompany)
{
	string Report;
	for (auto i = from; i <= to; i++)
	{
		int companyID = i->getId();

		int company_profit = profitCalculatorsByCompany[companyID].calculateProfit(*i);
		string company_report = i->getName() + " = " + to_string(company_profit);
		if (i == to)
		{
			Report += company_report;
			return Report;
		}
		else
		{
			Report += company_report + "\n";
		}
	}
}


#endif // !PROFIT_REPORT_H
