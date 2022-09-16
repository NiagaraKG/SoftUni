#include <iostream>
#include <climits>

using namespace std;

int main()
{
    int N, a, MAX = INT_MIN, MIN = INT_MAX;
    cin >> N;
    for(int i = 1; i <= N; i++)
    {
        cin >> a;
        if(a > MAX)
        {
            MAX = a;
        }
        if(a < MIN)
        {
            MIN = a;
        }
    }
    cout << MIN << " " << MAX << endl;
     return 0;
}
