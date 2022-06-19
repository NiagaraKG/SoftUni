#ifndef RESOURCE_H
#define RESOURCE_H

#include "ResourceType.h"

#include <string>

namespace SoftUni
{
    using namespace std;

    class Resource
    {
        int id;
        ResourceType type;
        string link;

    public:

        int getId() const
        {
            return this->id;
        }

        ResourceType getType() const
        {
            return this->type;
        }

        bool operator<(const Resource& other) const
        {
            return this->id < other.id;
        }

        friend void operator>>(istream& In, Resource& r);
        friend ostream& operator<<(ostream& Out, const Resource& r);
    };
    void operator>>(istream& In, Resource& r)
    {
        string t;
         In >> r.id >> t >> r.link;
         if(t == "Presentation")
         {
            r.type = PRESENTATION;
         }
        else if(t == "Demo")
        {
            r.type = DEMO;
        }
        else
        {
            r.type = VIDEO;
        }
    }
    ostream& operator<<(ostream& Out, const Resource& r)
    {
        return Out << r.id << " " << r.type << " " << r.link;
    }
}

#endif // !RESOURCE_H
