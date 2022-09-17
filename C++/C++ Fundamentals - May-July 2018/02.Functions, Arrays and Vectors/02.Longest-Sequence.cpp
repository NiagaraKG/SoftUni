#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int Size, num, MAX_Value = 0, repeat = 1;
	cin >> Size;
	vector<int> numbers;
	vector<int> MAX;
	vector<int> repeats;
	for (int i = 0; i < Size; i++)
	{
		cin >> num;
		numbers.push_back(num);
	}
	for (int i = 1; i < Size; i++)
	{
		if (numbers[i] == numbers[i - 1])
		{
			repeat++;
		}
		else
		{
			repeats.push_back(repeat);
			repeat = 1;
		}
	}
	for (int i = 0; i < repeats.size(); i++)
	{
		if (repeats[i] >= MAX_Value)
		{
			MAX_Value = repeats[i];
		}
	}
	if (MAX_Value == 1)
	{
		cout << numbers[numbers.size() - 1] << " ";
	}
	else
	{
		for (int i = 0; i < MAX_Value; i++)
		{
			cout << numbers[MAX_Value] << " ";
		}
	}
	cout << endl;
	return 0;
}
