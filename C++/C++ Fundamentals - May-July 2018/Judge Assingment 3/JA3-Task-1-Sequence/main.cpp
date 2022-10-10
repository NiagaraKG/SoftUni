#include <iostream>
#include <vector>

using namespace std;

int main()
{
    int n, num, MAX = 1, current = 1;
    vector<int> sequence;
    cin >> n;
    for(int i = 0; i < n; i++)
    {
        cin >> num;
        sequence.push_back(num);
    }
    for(int i = 1; i < n; i++)
    {
        if(sequence[i] > sequence[i-1])
        {
            current++;
        }
        else
        {
            if(current > MAX)
            {
                MAX = current;
            }
            current = 1;
        }
    }
    if(current > MAX)
    {
        MAX = current;
    }
    cout << MAX << endl;
    return 0;
}
