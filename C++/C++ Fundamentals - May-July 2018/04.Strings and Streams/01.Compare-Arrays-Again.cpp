#include <iostream>
#include <vector>
#include <string>
#include <sstream>

using namespace std;

vector<int> ReadVector()
{
    vector<int> numbers;

   string line;
   getline(cin, line);
   std::istringstream LineIn(line);
   int num;
   while(LineIn >> num)
   {
       numbers.push_back(num);
   }
   return numbers;
}
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
	vector<int> arr1 = ReadVector();
	vector<int> arr2 = ReadVector();
	int size1 = arr1.size();
	int size2 = arr2.size();
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
