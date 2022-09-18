#include <iostream>
#include <vector>
#include <cmath>
#include <climits>

using namespace std;

int main()
{
	int Size, result, num, MIN_Value = INT_MAX;
	cin >> Size;
	vector<int> numbers;
	vector<int> results;

	for (int i = 0; i < Size; i++)
	{
		cin >> num;
		numbers.push_back(num);
	}
	for (int i = 0; i < Size; i++)
	{
		for (int j = 0; j < Size; j++)
		{
			result = abs(numbers[i] - numbers[j]);
			if(j != i)
            {
                results.push_back(result);
            }
		}
	}
	for (int i = 0; i < results.size(); i++)
	{
		if (results[i] < MIN_Value)
		{
			MIN_Value = results[i];
		}
	}
	cout << MIN_Value;
	return 0;
}
