#include <iostream>
#include <vector>

using namespace std;

int main()
{
	vector<char> DNA1;
	char character = 0;
	//DNA1
	for (int i = 0; i < 5; i++)
	{
		cin.sync_with_stdio(false);
		cin >> character;
		DNA1.push_back(character);
	}
	while (character != '.')
	{
		vector<char> DNA2;
		//DNA2
		for (int i = 0; i < 5; i++)
		{
			cin.sync_with_stdio(false);
			cin >> character;
			if (character == '.')
			{
				 for (int i = 0; i < 5; i++)
				{
					cout.sync_with_stdio(false);
					cout << DNA1[i];
				}
				cout << endl;
				return 0;
			}
			DNA2.push_back(character);
		}
		//XOR
		for (int i = 0; i < 5; i++)
		{
			DNA1[i] = DNA1[i] ^ DNA2[i];
		}
	}
}
