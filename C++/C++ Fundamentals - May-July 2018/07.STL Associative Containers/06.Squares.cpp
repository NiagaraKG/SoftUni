#include <iostream>
#include <vector>
#include <string>
#include <sstream>
#include<math.h>
#include <algorithm>

using namespace std;

bool Is_Square(int number)
{
    double d_sqrt = sqrt(number);
    int i_sqrt = d_sqrt;
    return d_sqrt == i_sqrt;
}
int main()
{
    vector<int> squares;
    string input;
    getline(cin, input);
    istringstream Input(input);
    int current;
    while(Input >> current)
    {
        if(Is_Square(current))
        {
            squares.push_back(current);
        }
    }
    while(!squares.empty())
    {
         auto MAX = max_element(squares.begin(), squares.end());
         cout << *MAX << " ";
         squares.erase(MAX);
    }
    return 0;
}
