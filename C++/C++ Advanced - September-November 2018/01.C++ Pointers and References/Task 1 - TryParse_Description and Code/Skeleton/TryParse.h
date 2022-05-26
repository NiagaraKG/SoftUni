#ifndef TRYPARSE_H
#define TRYPARSE_H

#include <string>
#include <sstream>
#include <cctype>

using namespace std;

bool tryParse(string input, int& num)
{
    if(isdigit(input[0]) || isdigit(input[1]))
    {
        istringstream In(input);
        In >> num;
        return true;
    }
    return false;
}

#endif // !TRYPARSE_H
