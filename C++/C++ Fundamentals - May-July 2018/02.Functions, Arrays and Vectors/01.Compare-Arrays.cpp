#include <iostream>
#include <vector>

using namespace std;

bool areEqual(vector<int> arr1, int length1, vector<int> arr2, int length2)
{
	if (length1 != length2)
	{
		return false;
	}
	else
	{
		for (int i = 0; i < length1; i++)
		{
			if (arr1[i] != arr2[i])
			{
				return false;
			}
		}
	}
	return true;
}
int main()
{
	int size1, size2, num;
	cin >> size1;
	vector<int> arr1;
	vector<int> arr2;
	for (int i = 0; i < size1; i++)
	{
		cin >> num;
		arr1.push_back(num);
	}
	cin >> size2;
	for (int i = 0; i < size2; i++)
	{
		cin >> num;
		arr2.push_back(num);
	}
	if (areEqual(arr1, size1, arr2, size2))
	{
		cout << "equal" << endl;
	}
	else
	{
		cout << "not equal" << endl;
	}
	return 0;
}
