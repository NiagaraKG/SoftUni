#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <sstream>

using namespace std;

vector< pair<string, string> > DivideCharacteristics(string line)
{
	vector< pair<string, string> > result;
	pair<string, string> current;
	istringstream In(line);
	string first, second;
	while (In >> first)
	{
		In >> second;
		current = make_pair(first, second);
		result.push_back(current);
	}
	return result;
}

pair<string, string> DivideStrings(string queries)
{
	istringstream In(queries);
	string first, second;
	In >> first;
	In >> second;
	return make_pair(first, second);
}

int main()
{
	typedef pair<string, string> Characteristic;
	vector< vector< Characteristic > > Entities;
	string line;
	getline(cin, line);
	while (line != "[queries]")
	{
		vector< Characteristic > entity = DivideCharacteristics(line);
		Entities.push_back(entity);
		getline(cin, line);
	}
	string queries;
	getline(cin, queries);
	while (queries != "end")
	{
		bool not_found = true;
		bool no_such_field = true;
		pair<string, string> current = DivideStrings(queries);
		vector<vector<Characteristic> > found;
		for (vector<Characteristic> e : Entities)
		{
			for (Characteristic c : e)
			{
				if (c.second == current.first)
				{
					no_such_field = false;
					found.push_back(e);
				}
			}
		}
		if (no_such_field)
		{
			cout << "[not found]";
		}
		for (vector<Characteristic> e : found)
		{
			for (Characteristic c : e)
			{
				if (c.first == current.second)
				{
					cout << c.second << " ";
					not_found = false;
				}
			}
		}
		if (not_found && !no_such_field)
		{
			cout << "";
		}
		cout << endl;
		getline(cin, queries);
	}
	return 0;
}
