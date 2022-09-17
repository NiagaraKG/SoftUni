#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int Size, Sum = 0, num;
	double Average;
	cin >> Size;
	vector <int> numbers;
	for (int i = 0; i < Size; i++)
	{
		cin >> num;
		numbers.push_back(num);
		Sum += num;
	}
	Average = Sum / Size;
	for (int i = 0; i < Size; i++)
	{
		if (numbers[i] >= Average)
		{
			cout << numbers[i] << " ";
		}
	}
	cout << endl;
	return 0;
}
