#include <iostream>
#include <vector>
#include <climits>

using namespace std;

int main()
{
	int N, num, train_t, best_bus_t = INT_MAX;
	cin >> N;
	vector<int> araival_t;
	for (int i = 0; i < N; i++)
	{
		cin >> num;
		araival_t.push_back(num);
	}
	for (int i = 0; i < N; i++)
	{
		araival_t[i] = (araival_t[i] / 100) * 60 + araival_t[i] % 100;
	}
	cin >> train_t;
	train_t = (train_t / 100) * 60 + train_t % 100;
	for (int i = 0; i < N; i++)
	{
		if (train_t - araival_t[i] < best_bus_t && train_t - araival_t[i] >= 0)
		{
			best_bus_t = train_t - araival_t[i];
		}
	}
	for (int i = 0; i < N; i++)
	{
		if (train_t - araival_t[i] == best_bus_t)
		{
			cout << i + 1 << endl;
		}
	}
	return 0;
}
