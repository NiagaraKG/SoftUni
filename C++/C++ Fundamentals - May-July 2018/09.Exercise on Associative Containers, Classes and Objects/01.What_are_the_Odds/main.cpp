#include <iostream>
#include <string>
#include <map>
#include <set>
#include <sstream>

using namespace std;

int main()
{
    map<string,int> counts;
    set<string> evens;
    set<string> odds;
    string current;
    string input;
    getline(cin, input);
    istringstream Input(input);
    while(Input >> current)
    {
        counts[current]++;
    }
    for(auto i : counts)
    {
        if(i.second & 1)
        {
            odds.insert(i.first);
        }
        else
        {
            evens.insert(i.first);
        }
    }
    for(string word : odds)
    {
        cout << word << " ";
    }
    cout << endl;
    for(string word : evens)
    {
        cout << word << " ";
    }
    cout << endl;
    return 0;
}


/* *2 -> x - x << 1;
   /2 -> x - x >> 1;
   copy(copy_from.begin(), copy_from.end(), inserter(copy_to, copy to.begin()));  прехвърля от 1 контейнер в друг
   #include <iterator>
   #include <algorithm>
   copy(odds.begin(), odds.end(), ostream_iterator<string>{cout," "}); принтира на конзолата
    copy_n() -> copy от началото, колко елемента
*/
