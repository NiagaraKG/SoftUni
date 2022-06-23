#ifndef PRINTUTILS_H
#define PRINTUTILS_H

#include <iostream>
#include <vector>

template<typename T>
void printVector(const std::vector<T>& vec)
{
	for(auto i = vec.begin(); i != vec.end(); i++)
	{
		std::cout << *i << " ";
	}
	std::cout << std::endl;
}

#endif
