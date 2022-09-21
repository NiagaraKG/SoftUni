#include <iostream>
#include <string>
#include <ctype.h>

using namespace std;

bool IsNotLetter(char element)
{
    for(int a = 'A'; a <= 'Z'; a++)
    {
        if(element == a)
        {
            return false;
        }
    }
    for(int a = 'a'; a <= 'z'; a++)
    {
        if(element == a)
        {
            return false;
        }
    }
    return true;
}
int main()
{
   string text;
   getline(cin, text);
   text[0] = toupper(text[0]);
   for(int i = 1; i < text.size(); i++)
   {
       if(IsNotLetter(text[i]))
       {
           text[i+1] = toupper(text[i+1]);
       }
   }
   cout << text;
    return 0;
}
