#ifndef SERIALIZE_H
#define SERIALIZE_H

#include "Company.h"

#include <string>
#include <sstream>

using namespace std;

byte* serializeToMemory(string input, size_t& bytesWritten)
{
    vector<byte> Info;
    bytesWritten = 1;
    int numCompanies = 0;
    istringstream In(input);
    Company c;
    while (In >> c)
    {
        Info.push_back(c.getId());
        bytesWritten++;
        for(char i : c.getName())
        {
            Info.push_back(i);
            bytesWritten++;
        }
        Info.push_back(0);
        bytesWritten++;
        Info.push_back(c.getEmployees().size());
        bytesWritten++;
        for(auto e : c.getEmployees())
        {
            Info.push_back(e.first);
            Info.push_back(e.second);
            bytesWritten += 2;
        }
        numCompanies++;
    }
    byte* Memory = new byte[bytesWritten];
    Memory[0] = numCompanies;
    for(int i = 0; i < Info.size(); i++)
    {
        Memory[i+1] = Info[i];
    }
    return Memory;
}

#endif // !SERIALIZE_H
