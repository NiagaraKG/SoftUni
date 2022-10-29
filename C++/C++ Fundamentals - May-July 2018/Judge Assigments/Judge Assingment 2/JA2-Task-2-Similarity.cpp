#include <iostream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

vector<string> Divide_Words(string text)
{
	vector<string> words;
	istringstream textin(text);
	char symbol;
	for (int i = 0; i < text.size(); i++)
	{
		string curr_word;
		while (textin >> symbol)
		{
			if (symbol != '.' && symbol != ',' &&
				symbol != ';' && symbol != '!' &&
				symbol != '?')
			{
				curr_word.push_back(symbol);
			}
			else
			{
				words.push_back(curr_word);
				curr_word = "";
			}
		}
		words.push_back(curr_word);
	}
	return words;
}

int Check_Word(string curr_word, string check_word)
{
	int p, br = 0;
	if (curr_word[0] != check_word[0])
	{
		return -1;
	}
	if (curr_word.size() != check_word.size())
	{
		return -1;
	}
	for (int i = 0; i < check_word.size(); i++)
	{
		if (curr_word[i] == check_word[i])
		{
			br++;
		}
	}
	p = br * 100 / check_word.size();
	return p;
}

int main()
{
	int P, br = 0;
	string text, word;
	getline(cin, text);
	cin >> word >> P;
	for (int i = 0; i < text.size(); i++)
	{
		if (text[i] == ' ')
		{
			text[i] = ',';
		}
	}
	vector<string> words = Divide_Words(text);
	for (int i = 0; i < words.size(); i++)
	{
		if (Check_Word(words[i], word) >= P)
		{
			br++;
		}

	}
	cout << br << endl;
	return 0;
}
