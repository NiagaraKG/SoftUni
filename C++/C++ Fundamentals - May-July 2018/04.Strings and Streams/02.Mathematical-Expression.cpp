#include <iostream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

bool AreCorrect(string brackets, int br_opening, int br_closing)
{
    if(br_opening != br_closing)
    {
        return false;
    }
    else
    {
        istringstream textIn(brackets);
        string currentCouple[2];
       for(int i = 0; i < brackets.size() / 2; i++)
       {
            for(int i = 0; 1 < 2; i++)
            {
                istringstream textIn(brackets);
                string currentCouple[2];
                textIn >> currentCouple
                if(currentCouple[1] == ')' && currentCouple[2] == '(')
                {
                    return false;
                }
            }
        }
    }
    return true;
}
int main()
{
    string text;
    getline(cin, text);
    istringstream textIn(text);
    char currentChar;
    string brackets;
    int br_opening = 0;
    int br_closing = 0;
    while(textIn >> currentChar)
    {
       if(currentChar == '(')
       {
           brackets.push_back(currentChar);
           br_opening ++;
       }
       else if(currentChar == ')')
       {
           brackets.push_back(currentChar);
           br_closing ++;
       }
    }
    /*if(AreCorrect(brackets, br_opening, br_closing))
    {
        cout << "correct" << endl;
    }
    else
    {
        cout << "incorrect" << endl;
    }*/

    return 0;
}
