#include <iostream>
#include <vector>

using namespace std;

int main()
{
	int N, M, num, mod;
	cin >> N >> M;
	vector<int> result = { 0 };
	while (N != 0)
	{
		for (int i = 0; i < M; i++)
		{
			cin >> num;
			result[i] += num;

		}
		N--;
	}
	cin >> mod;
	for (int i = 0; i < M; i++)
	{
		result[i] = result[i] % mod;

	}
	for (int i = 0; i < M; i++)
	{
		cout << result[i] << " ";

	}
	cout << endl;
    return 0;
}
