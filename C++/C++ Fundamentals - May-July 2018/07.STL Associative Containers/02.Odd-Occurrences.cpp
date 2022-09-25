#include <iostream>
#include <map>
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
    map<string, int> words;
    string current;
    string input;
    getline(cin, input);
    istringstream Input(input);
    while(Input >> current)
    {
        current = ToLower(current);
        words[current]++;
    }
    istringstream Sequence(input);
    vector<string> sequence;
    while(Sequence >> current)
    {
        current = ToLower(current);
        if(words[current] % 2 == 1)
        {
            bool repeat = false;
             for(string word : sequence)
             {
                 if (current == word)
                 {
                     repeat = true;
                     break;
                 }
             }
             if(!repeat)
             {
                 sequence.push_back(current);
             }
        }
    }
    cout << sequence[0];
    for(int i = 1; i < sequence.size(); i++)
    {
        cout << ", " << sequence[i];
    }

    return 0;
}
