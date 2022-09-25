#include <iostream>
#include <map>
#include <string>
#include <sstream>

using namespace std;

int main()
{
	map <double, int> occurrences;
	double current;
	string input;
	getline(cin, input);
	istringstream Input(input);
	while (Input >> current)
	{
		occurrences[current]++;
	}
	for (auto key_value : occurrences)
	{
		cout << key_value.first << " -> " << key_value.second << endl;
	}
	return 0;
}
