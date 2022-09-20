#include <iostream>

using namespace std;

int main()
{
    // == fixed setprecision()
    cout.setf(ios::fixed);
    cout.precision(18);

    double sum = 0;
    for(int i = 0; i < 100; i++)
    {
        sum += 0.01;
        cout << sum << endl;
    }

  //time: 02:16:31
    return 0;
}
