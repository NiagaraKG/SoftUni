#include <iostream>
#include <set>
#include <algorithm>
#include <string>
#include <sstream>

using namespace std;

int main()
{
    set<double> numbers;
    double current;
    string input;
    getline(cin,input);
    istringstream Input(input);
    while(Input >> current)
    {
        numbers.insert(current);
    }
    if(numbers.size() < 3)
    {
        while(!numbers.empty())
        {
            auto MAX = max_element(numbers.begin(), numbers.end());
            cout << *MAX << " ";
            numbers.erase(MAX);
        }
    }
    else
    {
        auto MAX = max_element(numbers.begin(), numbers.end());
        cout << *MAX << " ";
        numbers.erase(MAX);
        MAX = max_element(numbers.begin(), numbers.end());
        cout << *MAX << " ";
        numbers.erase(MAX);
        MAX = max_element(numbers.begin(), numbers.end());
        cout << *MAX << endl;
    }
    return 0;
}
