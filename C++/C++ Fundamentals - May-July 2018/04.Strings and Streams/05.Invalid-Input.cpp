#include <iostream>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

vector<string> ReadVector()
{
    vector<string> text;

   string line;
   getline(cin, line);
   std::istringstream LineIn(line);
   string word;
   while(LineIn >> word)
   {
       text.push_back(word);
   }
   return text;
}

bool IsNumber(string element)
{
   char first_element = element[0];
    for(char a = 'A'; a <= 'Z'; a++)
    {
        if(first_element == a)
        {
            return false;
        }
    }
    for(int a = 'a'; a <= 'z'; a++)
    {
        if(first_element == a)
        {
            return false;
        }
    }
    return true;
}
int main()
{
   vector<string> text = ReadVector();
   vector<string> invalid;
   int number, sum = 0;
    for(int i = 0; i < text.size(); i++)
   {
           if(IsNumber(text[i]))
            {
                std::istringstream in(text[i]);
                in >> number;
                sum += number;
            }
            else
            {
                invalid.push_back(text[i]);
            }
   }
   cout << sum << endl;
   for(int i = 0; i < invalid.size(); i++)
   {
       cout << invalid[i] << " ";
   }
   cout << endl;
    return 0;
}
