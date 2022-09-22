#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
    string text;
    string search_str;
    string replace_str;
    getline(cin, text);
    getline(cin, search_str);
    getline(cin, replace_str);
    for(int position = text.find(search_str);
        position != std::string::npos;
        position = text.find(search_str, position +1))
        {

             text.replace(text.find(search_str), search_str.size(), replace_str);

        }
    cout << text;
    return 0;
}
