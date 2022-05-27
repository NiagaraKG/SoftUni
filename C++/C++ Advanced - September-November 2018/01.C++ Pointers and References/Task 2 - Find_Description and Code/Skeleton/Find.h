#ifndef FIND_H
#define FIND_H

#include "Company.h"
#include <vector>

using namespace std;

Company* find(vector<Company*> companies, int searchId)
{
    for(Company* c : companies)
    {
        if(c->getId() == searchId)
        {
          return c;
        }
    }
    return nullptr;
}

#endif // !FIND_H

