#include <iostream>
#include <vector>
#include <string>
#include <sstream>

using namespace std;

vector<vector<int> > ReadMatrix(int Size)
{
	cin.ignore();
	vector<vector<int> > numbers;
	for (int i = 0; i < Size; i++)
	{
		vector<int> row;
		string line;

		getline(cin, line);
		std::istringstream LineIn(line);
		int num;
		while (LineIn >> num)
		{
			row.push_back(num);
		}
		numbers.push_back(row);
	}
	return numbers;
}

bool areEqual(vector<vector<int> > arr1, int size1, int length1, vector<vector<int> > arr2, int size2, int length2)
{
	if (length1 != length2 || size1 != size2)
	{
		return false;
	}
	else
	{
		for (int i = 0; i < size1; i++)
		{
			for (int a = 0; a < length1; a++)
			{
				if (arr1[i][a] != arr2[i][a])
				{
					return false;
				}
			}
		}
	}
	return true;
}

int main()
{
	int number, first_rows, second_rows, first_cols, second_cols;
	cin >> first_rows;
	vector<vector<int> > first_matrx = ReadMatrix(first_rows);
	cin >> second_rows;
	vector<vector<int> > second_matrx = ReadMatrix(second_rows);
	first_cols = first_matrx[0].size();
	second_cols = second_matrx[0].size();
	if (areEqual(first_matrx, first_rows, first_cols, second_matrx, second_rows, second_cols))
	{
		cout << "equal" << endl;
	}
	else
	{
		cout << "not equal" << endl;
	}
	return 0;
}
