#ifndef SUMOFVECTORS_H
#define SUMOFVECTORS_H

#include <vector>
#include <string>

using namespace std;

vector<string> operator+ (const vector<string>& vec1, const vector<string>& vec2)
{
    vector<string> vec3;
    for(auto i = 0; i < vec1.size(); i++)
    {
        string line;
        line += vec1[i] + " " + vec2[i];
        vec3.push_back(line);
    }
    return vec3;
}

#endif // !SUMOFVECTORS_H
