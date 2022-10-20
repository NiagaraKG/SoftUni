#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <sstream>

using namespace std;

vector<string> getStrings(string originalString)
{
    vector<string> strings;
    istringstream in(originalString);
    string s;
    while(in >> s)
    {
        strings.push_back(s);
    }
    return strings;
}

vector<string> ReadLineofStrings()
{
    string line;
    getline(cin,line);
    return getStrings(line);
}

int main()
{
    vector<string> keys = ReadLineofStrings();
    vector<map<string, string> > entities;
    string line;
    getline(cin, line);
    while(line != "end")
    {
        vector<string> values = getStrings(line);
        map<string, string> e;
        for(int i = 0; i < keys.size(); i++)
        {
            e[keys[i]] = values[i];
        }
        entities.push_back(e);
        getline(cin, line);
    }
    string searchkey;
    getline(cin, searchkey);
    map<string,int> occurrencesByvalue;
    for(map<string, string> e : entities)
    {
        occurrencesByvalue[e[searchkey]]++;
    }
    string maxValue;
    int Maxoccurences = 0;
    for(pair<string,int> occurrenceByvalue : occurrencesByvalue)
    {
        if(occurrenceByvalue.second > Maxoccurences)
        {
            Maxoccurences = occurrenceByvalue.second;
            maxValue = occurrenceByvalue.first;
        }
    }
    cout << maxValue << " " << Maxoccurences << endl;
    return 0;
}
