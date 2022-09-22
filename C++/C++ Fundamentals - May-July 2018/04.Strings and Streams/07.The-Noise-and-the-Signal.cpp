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
    bool IsNoNoise = true;
	string word;
	vector<string> text = ReadVector();
	for (int i = 0; i < text.size(); i++)
	{
		for (int j = 0; j <text[i].size(); j++)
		{
			word = text[i];
			if (!IsNotNumber(word[j]))
			{
				text[i].erase(j, 1);
				j--;
				IsNoNoise = false;
			}
		}
	}
        string MAX = text[0];
        for (int i = 1; i < text.size(); i++)
        {
            if (text[i].size() > MAX.size())
            {
                MAX = text[i];
            }
            else if (text[i].size() == MAX.size())
            {
                if(text[i] < MAX)
                {
                    MAX = text[i];
                }
            }
        }
        if(MAX < "!")
        {
           cout << "no noise" << endl;
        }
        else
        {
            cout << MAX << endl;
        }
	return 0;
}
