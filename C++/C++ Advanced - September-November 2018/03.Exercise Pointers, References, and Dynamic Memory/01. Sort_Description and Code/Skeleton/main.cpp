#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

#include "Company.h"

using namespace std;

bool AreInOrderById(const Company& a, const Company& b)
{
    return a.getId() < b.getId();
}

bool AreInOrderByName(const Company& a, const Company& b)
{
    return a.getName() < b.getName();
}

int main()
{
    vector<Company> companies;
    string line;
    getline(cin, line);
    while(line != "end")
    {
        int ID;
        string Name;
        istringstream In(line);
        In >> Name;
        In >> ID;
        Company c(ID, Name);
        companies.push_back(c);
        getline(cin, line);
    }
    string sortBy;
    getline(cin, sortBy);
    if(sortBy == "id")
    {
        sort(companies.begin(), companies.end(), AreInOrderById);
    }
    else
    {
        sort(companies.begin(), companies.end(), AreInOrderByName);
    }
    for(auto company : companies)
    {
        cout << company.toString() << endl;
    }
    return 0;
}
