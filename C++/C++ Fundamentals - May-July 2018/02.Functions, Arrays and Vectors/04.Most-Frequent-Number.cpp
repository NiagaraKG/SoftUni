#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int Size, num, MAX_Value = 1;
	cin >> Size;
	vector<int> numbers;
	vector<int> MAX;
	int repeats[10] = { 0 };
	for (int i = 0; i < Size; i++)
	{
		cin >> num;
		numbers.push_back(num);
		for (int j = 0; j <= 9; j++)
		{
			if (num == j)
			{
				repeats[j]++;
			}
		}
	}
	for (int i = 0; i <= 9; i++)
	{
		if (repeats[i] > MAX_Value)
		{
			MAX_Value = repeats[i];
		}
	}
	for (int i = 0; i <= 9; i++)
	{
		if (repeats[i] == MAX_Value)
		{
			MAX.push_back(i);
		}
	}
	for (int i = 0; i < MAX.size(); i++)
	{
		cout << MAX[i] << " ";
	}
	cout << endl;
	return 0;
}
