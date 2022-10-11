#include <iostream>
#include <string>
#include <stack>

using namespace std;

string Copy(int pos1, int pos2, string text)
{
	int start_pos = 0;
	for (int i = pos1; i >= 0; i--)
	{
		if (text[i] == ' ')
		{
			start_pos = i + 1;
			break;
		}
	}
	return text.substr(start_pos, text.find(' ', pos2) - start_pos);;
}

string Paste(string clipboard, int pos, string text)
{
	if (text[pos] == ' ')
	{
		clipboard = " " + clipboard;
	}
	text.insert(pos, clipboard);
	return text;
}

int main()
{
	cin.sync_with_stdio(false);
	cout.sync_with_stdio(false);
	string text;
	string operation;
	stack<string> clipboard;
	int pos1, pos2;
	getline(cin, text);
	cin >> operation;
	while (operation != "end")
	{
		cin >> pos1;
		if (operation == "copy")
		{
			cin >> pos2;
			clipboard.push(Copy(pos1, pos2, text));
		}
		else if (!clipboard.empty())
		{
			text = Paste(clipboard.top(), pos1, text);
			clipboard.pop();
		}
		cin >> operation;
	}
	cout << text << endl;
	return 0;
}
