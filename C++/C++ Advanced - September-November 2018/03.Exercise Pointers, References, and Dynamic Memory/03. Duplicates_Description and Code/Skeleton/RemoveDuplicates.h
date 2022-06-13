#ifndef REMOVE_DUPLICATES_H
#define REMOVE_DUPLICATES_H

#include "Company.h"

#include <list>
#include <set>

using namespace std;

void removeDuplicates(list<Company*>& companies)
{
    set<Company*> uniquePtrs;
    set<string> uniqueNames;
    auto i = companies.begin();
    while(i != companies.end())
    {
        Company* company = *i;

        bool isPtrCopy = !uniquePtrs.insert(company).second;
        if(isPtrCopy)
        {
            i = companies.erase(i);
        }
        else
        {
            bool isNameCopy = !uniqueNames.insert(company->getName()).second;
           if(isNameCopy)
           {
                i = companies.erase(i);
                 delete company;
           }
           else
           {
                i++;
           }
        }

     }
}

#endif // !REMOVE_DUPLICATES_H
