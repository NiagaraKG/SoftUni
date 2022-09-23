#include <iostream>
#include <queue>
#include <vector>
#include <stack>
#include <string>
#include <sstream>

using namespace std;

stack<int> ReadMatrix()
{
	stack<int> numbers;
	string line;
	getline(cin, line);
	std::istringstream LineIn(line);
	int num;
	while (LineIn >> num)
	{
		numbers.push(num);
	}
	return numbers;
}

int main()
{
	stack<int> trackA = ReadMatrix();
	stack<int> trackB = ReadMatrix();
	vector<char> track_order;
	vector<int> train;
	while (trackA.size() != 0 || trackB.size())
	{
		if (trackA.size() == 0)
		{
			for (int i = 0; i < trackB.size(); i++)
			{
				train.push_back(trackB.top());
				trackB.pop();
				track_order.push_back('B');
			}
		}
		else if (trackB.size() == 0)
		{
			for (int i = 0; i < trackA.size(); i++)
			{
				train.push_back(trackA.top());
				trackA.pop();
				track_order.push_back('A');
			}
		}
		else if (trackA.top() < trackB.top())
		{
			train.push_back(trackA.top());
			trackA.pop();
			track_order.push_back('A');
		}
		else
		{
			train.push_back(trackB.top());
			trackB.pop();
			track_order.push_back('B');
		}
	}
	for (int i = 0; i < track_order.size(); i++)
	{
		cout << track_order[i];
	}
	cout << endl;
	for (int i = train.size() - 1; i >= 0; i--)
	{
		cout << train[i] << " ";
	}
	cout << endl;
	return 0;
}
