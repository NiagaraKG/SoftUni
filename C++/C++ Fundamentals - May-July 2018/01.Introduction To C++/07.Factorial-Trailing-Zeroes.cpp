#include <iostream>

using namespace std;

int main()
{
    int n, br = 0;
    cin >> n;
    for (int i = 5; i <= n; i *= 5)
    {
        br += n / i;
    }
    cout << br << endl;
    return 0;
}
