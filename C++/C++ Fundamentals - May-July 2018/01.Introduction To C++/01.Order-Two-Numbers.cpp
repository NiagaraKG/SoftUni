#include <iostream>

using namespace std;

int main()
{
    int first_num, second_num;
    cin >> first_num >> second_num;
    if(first_num > second_num)
    {
        cout << second_num  << " " << first_num;
    }
    else
    {
        cout << first_num << " " << second_num;

    }
    return 0;
}
