#include <iostream>
#include <string>

using namespace std;

int main()
{
    int repeats = 1;
    char repeating;
    string compressed;
    string input;
    cin >> input;
    string output = "";
    for(int i = 0; i < input.size(); i++)
    {
        repeating = input[i];
        if(input[i] == input[i+ 1])
        {
            repeats++;
        }
        else
        {   if(repeats > 2)
            {
                compressed = to_string(repeats) + repeating;
            }
            else
            {
                compressed = string(repeats,repeating);
            }
            output += compressed;
            repeats = 1;
        }
    }
    cout << output << endl;
    return 0;
}
