#include "Big_Int.h"

#include <iostream>

using namespace std;

bool CanDivide(BigInt From)
{
	string digits = From.getDigits();
	char last = digits.back();
	if (last != '0' && last != '5')
	{
		return false;
	}
	int sum = 0;
	for (int i = 0; i != digits.size(); i++)
	{
		char c = digits[i];
		sum += (c - '0');
	}
	if (sum % 9 != 0)
	{
		return false;
	}
	return true;
}

int main()
{
	string from, to;
	cin >> from >> to;
	BigInt From(from);
	BigInt To(to);
	while (From < To)
	{
		if (CanDivide(From))
		{
			break;
		}
		From += 1;
	}
	while (From < To)
	{
		cout << From << endl;
		From += 45;
	}
	return 0;
}