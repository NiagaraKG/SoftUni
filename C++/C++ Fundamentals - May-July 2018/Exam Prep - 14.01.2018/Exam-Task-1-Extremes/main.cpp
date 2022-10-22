#include <iostream>
#include <vector>
#include <iterator>
#include <cmath>
#include <algorithm>

using namespace std;

int main()
{
	int D, N, Min, Max, br = 0;
	double Average = 0;
	vector<int> incomes;
	int current_income;
	cin >> D >> N;
	while (N > 0)
	{
		cin >> current_income;
		incomes.push_back(current_income);
		N--;
	}
	sort(incomes.begin(), incomes.end());
	Min = *(incomes.begin());
	Max = *(incomes.rbegin());
	///***
	for (int i = 0; i < incomes.size(); i++)
	{
		if (incomes[i] <= Min + D || incomes[i] >= Max - D)
		{
			incomes[i] = 0;

		}
		else
		{
			Average += incomes[i];
			br++;
		}
	}
	Average = Average / br;
	cout << Average << endl;
	return 0;
}
