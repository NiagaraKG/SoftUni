#include <iostream>
#include <set>
#include <string>
#include <sstream>
#include <algorithm>

using namespace std;

string ToLower(string word)
{
    for(int i = 0; i < word.size(); i++)
    {
        if(word[i] >= 'A' && word[i] <= 'Z')
        {
            word[i] = word[i] + 32;
        }
    }
    return word;
}

int main()
{
    set<string> words;
    string current;
    string input;
    getline(cin, input);
    istringstream Input(input);
    while(Input >> current)
    {
        current = ToLower(current);
        if(current.size() < 5)
        {
            words.insert(current);
        }
    }
    auto first = min_element(words.begin(), words.end());
    cout << *first;
    words.erase(first);
    for(string word : words)
    {
        cout << ", " << word;
    }
    cout << endl;
    return 0;
}
