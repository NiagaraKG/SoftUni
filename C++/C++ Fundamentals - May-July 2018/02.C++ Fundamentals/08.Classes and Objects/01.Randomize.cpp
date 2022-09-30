#include <iostream>
#include <algorithm>
#include <vector>
#include <time.h>
#include <string>
#include <sstream>

using namespace std;

class Text
{
public:
	vector<string> words;

	void randomize(vector<string>& words, int n)
	{
		srand(time(NULL));
		for (int i = n - 1; i > 0; i--)
		{
			int j = rand() % (i + 1);
			string temp = words[i];
			words[i] = words[j];
			words[j] = temp;
		}
	}
};


void printText(vector<string>& words)
{
	for (auto word = words.begin(); word < words.end(); word++)
	{
		cout << *word << endl;
	}
}


int main()
{
	Text text;
	string input;
	getline(cin, input);
	istringstream Input(input);
	string word;
	while (Input >> word)
	{
		text.words.push_back(word);
	}
	int n = text.words.size();
	text.randomize(text.words, n);
	for (string word : text.words)
	{
		cout << word << endl;
	}

	return 0;
}
