#include <iostream>
#include <string>
#include <sstream>
#include <set>

using namespace std;

int main()
{
    int current;
    set<int> first_row;
    set<int> second_row;
    string first_input;
    string second_input;
    getline(cin, first_input);
    getline(cin, second_input);
    istringstream Input1(first_input);
    while(Input1 >> current)
    {
        first_row.insert(current);
    }
    istringstream Input2(second_input);
    while(Input2 >> current)
    {
        second_row.insert(current);
    }
    bool no_matches = true;
    for(int num1 : first_row)
    {
        for(int num2 : second_row)
        {
            if(num1 == num2)
            {
                cout << num1 << " ";
                no_matches = false;
                break;
            }
        }
    }
    if(no_matches)
    {
        cout << "no matches";
    }
    cout << endl;
    return 0;
}

/*
    #include <algorithm>
vector<int> matches;
    set_intersection(first.begin(), first.end(), second.begin(), second.end(), inserter(matches, matches.begin()));
*/
