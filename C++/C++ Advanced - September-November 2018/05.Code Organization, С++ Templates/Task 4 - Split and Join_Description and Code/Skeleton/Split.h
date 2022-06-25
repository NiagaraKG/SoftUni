#ifndef SPLIT_H
#define SPLIT_H

#include <vector>
#include <string>
#include <sstream>

using namespace std;

template<typename T>
std::vector<T> split(string line, char separator)
{
	vector<T> vec;
	istringstream Input(line);
	string curr;
	while (std::getline(Input, curr, separator))
	{
			istringstream In(curr);
			T current;
			In >> current;
			vec.push_back(current);
			curr = "";
	}
	return vec;
}

#endif // !SPLIT_H
