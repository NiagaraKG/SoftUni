#include <iostream>
#include <set>
#include <string>
#include <sstream>
#include <algorithm>
using namespace std;

int main()
{
    set<double> numbers;
    string input;
    getline(cin, input);
    istringstream Input (input);
    double current;
    while(Input >> current)
    {
        numbers.insert(current);
    }
    auto first = min_element(numbers.begin(), numbers.end());
            cout << *first;
            numbers.erase(first);
    for(double number : numbers)
    {
        cout << " <= " << number;
    }
    cout << endl;
    return 0;
}
