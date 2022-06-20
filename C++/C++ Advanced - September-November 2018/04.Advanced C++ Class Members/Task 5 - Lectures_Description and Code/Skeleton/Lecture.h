#ifndef LECTURE_H
#define LECTURE_H

#include "ResourceType.h"
#include "Resource.h"

#include<set>
#include<map>

namespace SoftUni
{
    using namespace std;

    class Lecture
    {
       map<int, Resource> ResourcesById;
       map<ResourceType, int> NumTypes;
       set<Resource> Resources;
       set<ResourceType> Types;

   public:
    void operator<<(Resource& R)
    {
        this->ResourcesById[R.getId()] = R;
        this->Types.insert(R.getType());
        Resources.clear();
        NumTypes.clear();
        for(auto r: ResourcesById)
        {
            this->NumTypes[r.second.getType()]++;
            Resources.insert(r.second);
        }

    }

    std::set<Resource>::iterator begin() const
    {
        return this->Resources.begin();
    }

    std::set<Resource>::iterator end() const
    {
        return this->Resources.end();
    }

     friend void operator<<(vector<ResourceType>& resourceTypes, const Lecture l)
    {
        if(l.Types.find(PRESENTATION) != l.Types.end())
        {
            resourceTypes.push_back(PRESENTATION);
        }
        if(l.Types.find(DEMO) != l.Types.end())
        {
            resourceTypes.push_back(DEMO);
        }
        if(l.Types.find(VIDEO) != l.Types.end())
        {
            resourceTypes.push_back(VIDEO);
        }
    }

    int operator[](ResourceType t)
    {
        return this->NumTypes[t];
    }

    };
}

#endif // !LECTURE_H
