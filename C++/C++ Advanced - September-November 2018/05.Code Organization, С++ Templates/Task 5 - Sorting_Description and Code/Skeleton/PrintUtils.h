#ifndef PRINTUTILS_H
#define PRINTUTILS_H

#include <iostream>
#include <iterator>

template<typename C>
void printContainer(const typename C::iterator& begin, const typename C::iterator& end)
{
	for(typename C::iterator i = begin; i != end; i++)
	{
		std::cout << *i << " ";
	}
	std::cout << std::endl;
}

#endif
