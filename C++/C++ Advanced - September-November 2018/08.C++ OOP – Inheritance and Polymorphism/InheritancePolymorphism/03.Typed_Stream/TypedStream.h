#ifndef TYPED_STREAM_H
#define TYPED_STREAM_H

#include "Vector2D.h"

#include <string>
#include <sstream>
#include<vector>

template<typename T>
class TypedStream
{
protected:
	std::istringstream stream;

	TypedStream(std::string input) : stream(input) {}

	virtual TypedStream<T>& operator>>(T& t) = 0;

public:
	std::vector<T> readToEnd()
	{
		T curr;
		std::vector<T> all;
		while (this->operator>>(curr).stream.good())
		{
			all.push_back(curr);
		}
		return all;
	}
};

#endif // !TYPED_STREAM_H
