#ifndef MIN_BY_H
#define MIN_BY_H

#include <vector>
#include <string>

using namespace std;

string minBy(vector<std::string> values, bool (*Characteristic)(const std::string&, const std::string&))
{
    if(values.size() == 1)
    {
        return values[0];
    }
    string Min = values[0];
    for(string curr : values)
    {
        if(Characteristic(curr,Min))
        {
            Min = curr;
        }
    }
    return Min;
}

#endif // !MIN_BY_H

