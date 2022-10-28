#include <iostream>
#include <vector>

using namespace std;

int main()
{
    int Size, num, damage, lifetime;
    cin >> Size;
    vector<int> checkup;
    for (int i = 0; i < Size; i++)
	{
		cin >> num;
		checkup.push_back(num);
	}
    vector<int> installation;
    for (int i = 0; i < Size; i++)
	{
	    int num;
		cin >> num;
		installation.push_back(num);
	}
    for(int i = 0; i < Size; i++)
    {
        damage = installation[i] - checkup[i];
        lifetime = installation[i] / damage;
        cout << lifetime << " ";
    }
    cout << endl;
    return 0;
}
