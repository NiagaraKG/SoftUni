#ifndef VECTOR_COMPARISONS_H
#define VECTOR_COMPARISONS_H

#include "Vector.h"

class VectorLengthComparer
{
public:
	bool operator() (const Vector& a, const Vector& b) 
	{
		return a.getLength() < b.getLength();
	}
};

template<typename T, typename Comparator>
class ReverseComparer
{
	Comparator comp;
public:
	bool operator()(const T& a, const T& b) 
	{
		bool ComparedResult = this->comp(a, b);
		return !ComparedResult;
	}
};

#endif
