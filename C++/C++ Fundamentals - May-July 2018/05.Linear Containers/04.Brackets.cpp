#include <iostream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

bool AreCorrect(string text)
{
	char bracket;
	int br_opening_kisses = 0, br_closing_kisses = 0,
		br_opening_square = 0, br_closing_square = 0,
		br_opening_curved = 0, br_closing_curved = 0;
	for(int i = 0; i < text.size(); i++)
	{
		bracket = text[i];
		if (bracket == '{')
		{
			br_opening_kisses++;
		}
		else if (bracket == '}')
		{
			br_closing_kisses++;
		}
		else if (bracket == '[')
		{
			br_opening_square++;
		}
		else if (bracket == ']')
		{
			br_closing_square++;
		}
		else if (bracket == '(')
		{
			br_opening_curved++;
		}
		else if (bracket == ')')
		{
			br_closing_curved++;
		}
	}
	if (br_opening_curved != br_closing_curved ||
		br_opening_kisses != br_closing_kisses ||
		br_opening_square != br_closing_square)
	{
		return false;
	}
	for (int i = 0; i < text.size(); i++)
	{
		if (text[i] == '[' && (text[i + 1] == '{' || text[i + 1] == '}' || text[i + 1] == ')'))
		{
			return false;
		}
		if (text[i] == '(' && (text[i + 1] != '(' && text[i + 1] != ')'))
		{
			return false;
		}
		if (text[i] == '{' && (text[i + 1] == ')' || text[i + 1] == ']'))
		{
			return false;
		}
	}
	return true;
}
int main()
{
	string text;
	getline(cin, text);
	if (AreCorrect(text))
	{
		cout << "valid" << endl;
	}
	else
	{
		cout << "invalid" << endl;
	}

	return 0;
}
