#ifndef SORT_BY_H
#define SORT_BY_H

#include "Company.h"
#include <algorithm>

void sortBy(Company** firstPtr, Company** lastPtr, bool (*lessThanBy)(const Company& a, const Company& b))
{
    std::sort(firstPtr, lastPtr, [&](Company* p1, Company* p2 ) {return lessThanBy(*p1, *p2);});
}

#endif // !SORT_BY_H
