#include <iostream>

using namespace std;

int main()
{
	double first_num, second_num, third_num;
	int br = 0;
	cin >> first_num >> second_num >> third_num;
	if (first_num < 0)
	{
		br++;
	}
	if (second_num < 0)
	{
		br++;
	}
	if (third_num < 0)
	{
		br++;
	}
	if (br % 2 == 0 )
	{
		cout << "+" << endl;
	}
	else
	{
		cout << "-" << endl;
	}
	return 0;
}
