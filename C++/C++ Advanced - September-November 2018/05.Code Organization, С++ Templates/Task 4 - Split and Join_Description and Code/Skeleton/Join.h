#ifndef JOIN_H
#define JOIN_H

#include <string>
#include <sstream>
#include <vector>

using namespace std;

template<typename T>
std::string join(std::vector<T> vec, string joinStr)
{
	ostringstream Out;
	for (auto i = vec.begin(); i != vec.end(); i++)
	{
		Out << *i;
		if (i + 1 != vec.end())
		{
			Out << joinStr;
		}
	}

	return Out.str();
}

#endif // !JOIN_H

