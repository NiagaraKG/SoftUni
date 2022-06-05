#ifndef REMOVE_INVALID_H
#define REMOVE_INVALID_H

#include "Company.h"

#include <list>
#include <iterator>
#include <algorithm>

using namespace std;

void removeInvalid(list<Company*>& companies)
{
    for(std::list<Company*>::iterator it = companies.begin(); it != companies.end();)
    {
        if((*it)->getId() < 0)
        {
          delete *it;
          it = companies.erase(it);
        }
        else
        {
            it++;
        }
    }
}
#endif // !REMOVE_INVALID_H
