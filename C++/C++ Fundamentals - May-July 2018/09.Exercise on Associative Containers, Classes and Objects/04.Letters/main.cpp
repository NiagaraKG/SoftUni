#include <iostream>
#include <string>
#include <sstream>
#include <map>
#include <set>
#include <cctype>
#include <vector>
#include <iterator>
#include <algorithm>

using namespace std;

vector<string> readLineOfWords()
{
    string line;
    getline(cin, line);
    vector<string> words;
    ostringstream currentWord;
    for(size_t i = 0; i < line.size(); i++)
    {
        char currentSymbol = line[i];
        if(isalpha(currentSymbol))
        {
            currentWord << currentSymbol;
            if(i == line.size() - 1)
            {
                words.push_back(currentWord.str());
            }
        }
        else
        {
            if(!currentWord.str().empty())
            {
                words.push_back(currentWord.str());
                currentWord.str("");
                currentWord.clear();
            }
        }
    }
    return words;
}

int main()
{
    vector<string> words = readLineOfWords();
    map<char, set<string> > lettersToWords;
    for (string word : words)
    {
        for(char letter : word)
        {
            lettersToWords[tolower(letter)].insert(word);
        }
    }
    char letter;
    cin >> letter;
    while(letter != '.')
    {
        auto wordsIter = lettersToWords.find(tolower(letter));
        if(wordsIter == lettersToWords.end())
        {
            cout << "---" << endl;
        }
        else
        {
            copy(wordsIter->second.begin(), wordsIter->second.end(), ostream_iterator<string>(cout, " "));
            cout << endl;
        }
        cin >> letter;
    }
    return 0;
}
