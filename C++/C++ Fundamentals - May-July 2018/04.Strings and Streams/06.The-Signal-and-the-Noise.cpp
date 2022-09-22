#include <iostream>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

vector<string> ReadVector()
{
	vector<string> text;

	string line;
	getline(cin, line);
	std::istringstream LineIn(line);
	string word;
	while (LineIn >> word)
	{
		text.push_back(word);
	}
	return text;
}

bool IsNotNumber(char element)
{
	for (char n = '0'; n <= '9'; n++)
	{
		if (element == n)
		{
			return false;
		}
	}
	return true;
}
int main()
{
	string word;
	vector<string> text = ReadVector();
	vector<int> numbers;
	int number;
	for (int i = 0; i < text.size(); i++)
	{
		for (int j = 0; j <text[i].size(); j++)
		{
			word = text[i];
			if (IsNotNumber(word[j]))
			{
				text[i].erase(j, 1);
				j--;
			}
		}
		std::istringstream in(text[i]);
		in >> number;
		numbers.push_back(number);
	}
	int MAX = numbers[0];
	for (int i = 1; i < numbers.size(); i++)
	{
		if (numbers[i] > MAX)
		{
			MAX = numbers[i];
		}
	}
	cout << MAX << endl;
	return 0;
}
