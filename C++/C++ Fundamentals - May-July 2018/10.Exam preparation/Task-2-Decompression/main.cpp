#include <iostream>
#include <string>

using namespace std;

int main()
{
    string text;
    cin >> text;
    int count = 0;
    for(int i = 0; i < text.size(); i++)
    {
        if(isdigit(text[i]))
        {
            int digit = text[i] - '0';
            count *= 10;
            count += text[i]-'0';
        }
        else
        {
            if(count == 0)
            {
                cout << text[i];
            }
            else
            {
                for(int c = 0; c < count; c++)
                {
                    cout << text[i];
                }
                count = 0;
            }
        }
    }
    return 0;
}
