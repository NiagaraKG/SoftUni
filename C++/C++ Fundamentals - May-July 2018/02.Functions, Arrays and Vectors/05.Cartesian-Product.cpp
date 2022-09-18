#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int Size, result, num;
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
			result = numbers[i] * numbers[j];
			results.push_back(result);
		}
	}
	for (int i = 0; i < results.size(); i++)
	{
		cout << results[i] << " ";
	}
	return 0;
}
