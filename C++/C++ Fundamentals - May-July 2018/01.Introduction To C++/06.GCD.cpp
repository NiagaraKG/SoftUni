#include <iostream>

using namespace std;

int main()
{
    int a, b, buf;
    cin >> a >> b;
    while(b != 0)
    {
        buf = b;
        b = a % b;
        a = buf;
    }
    cout << a;
    return 0;
}
