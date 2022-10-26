#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <utility>
#include <sstream>

using namespace std;

bool IsClear(string input)
{
	auto i = input.find('?');
	if (i == string::npos)
	{
		return true;
	}
	return false;
}

pair<int, pair< double, string> > Divide(string input)
{
	double frequency;
	int priority;
	string message, num;
	char c;
	istringstream In(input);
	In >> frequency;
	while (In >> c)
	{
		if (isdigit(c))
		{
			num += c;
		}
		else
		{
			message += c;
		}
	}
	istringstream N(num);
	N >> priority;
	pair<int, pair< double, string> > p = make_pair(priority, make_pair(frequency, message));
	return p;
}

pair<double, string> Get_Frequency(string input)
{
	istringstream In(input);
	double frequency;
	In >> frequency;
	string text;
	In >> text;
	return make_pair(frequency, text);
}

string Clear(string input, unordered_map<double, string> To_clear)
{
	pair<double, string> to_clear = Get_Frequency(input);
	for (auto t : To_clear)
	{
		if (t.first == to_clear.first)
		{
			for (size_t i = 0; i < to_clear.second.size(); i++)
			{
				if (to_clear.second[i] == '?')
				{
					to_clear.second[i] = t.second[i];
				}
			}
			t.second = to_clear.second;
			break;
		}
	}
	input = to_string(to_clear.first) + " " + to_clear.second;
	return input;
}

int main()
{
	cin.sync_with_stdio(false);
	cout.sync_with_stdio(false);

	unordered_map<double, string> To_clear;
	map<int, pair< double, string> > Cleared;
	unordered_set<double> Reported;
	string input;

	getline(cin, input);
	while (input != "end")
	{
		if (input == "report")
		{
			if (Cleared.empty())
			{
				cout << "[no new messages]" << endl;
			}
			else
			{
				cout << (--Cleared.end())->second.second << endl;
				Reported.insert((--Cleared.end())->second.first);
				Cleared.erase((--Cleared.end()));
			}
		}
		else
		{
			auto it = Reported.find(Get_Frequency(input).first);
			if(it == Reported.end())
			{
				if (IsClear(input))
				{
					Cleared.insert(Divide(input));
				}
				else
				{
					input = Clear(input, To_clear);
					if (IsClear(input))
					{
						//Cleared.insert(Divide(input));
						Cleared[Divide(input).first] = Divide(input).second;
						if (To_clear.find(Divide(input).first) != To_clear.end())
						{
							To_clear.erase(To_clear.find(Divide(input).first));
						}
					}
					else
					{
						To_clear[Get_Frequency(input).first] = (Get_Frequency(input).second);
					}

				}
			}
		}
		getline(cin, input);
	}
	return 0;
}
