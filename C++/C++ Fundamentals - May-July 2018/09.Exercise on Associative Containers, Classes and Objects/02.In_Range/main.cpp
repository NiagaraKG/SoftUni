#include <iostream>
#include <string>
#include <sstream>
#include <set>
using namespace std;

int main()
{
    set<int> numbers;
    string input;
    int start_num, end_num, current;
    getline(cin, input);
    cin >> start_num >> end_num;
    istringstream Input(input);
    while(Input >> current)
    {
        if(current >= start_num && current < end_num)
        {
            numbers.insert(current);
        }
    }
    for(int number :numbers)
    {
        cout << number << " ";
    }
    return 0;
}
/*
    for(auto i = numbers.lower_bound(start_num); i != numbers.lower_bound(end_num; i++)
    {cout << *i << " ";}         ^^връща най-малкото число >= start_num

    #include <algorithm>
    #include <iterator>
    copy(numbers.lower_bound(start_num),numbers.lower_bound(end_num),ostream_iterator<int>(cout, " "));

    upper_bound() -> ако включваме горната граница
*/
