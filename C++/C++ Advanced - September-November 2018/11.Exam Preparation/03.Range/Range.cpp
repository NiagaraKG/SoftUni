#include "Range.h"

#include <cstdlib>

Range::Range() : rangeLength(0), valueCounts(nullptr) {}

void Range::add(T value) 
{
	if (this->rangeLength == 0)
	{
		this->rangeFirst = value;
		this->rangeLength = 1;
		this->valueCounts = new size_t[1];
		this->valueCounts[0] = 1;
	}
	else if (value < this->rangeFirst)
	{
		resize(value, this->rangeFirst + this->rangeLength - 1);
		this->valueCounts[0] ++;
		this->rangeLength = this->rangeLength + (this->rangeFirst - value);
		this->rangeFirst = value;

	}
	else if (value >= this->rangeFirst + this->rangeLength)
	{
		resize(this->rangeFirst, value);
		this->valueCounts[value - this->rangeFirst] ++;
		this->rangeLength = value - this->rangeFirst + 1;
	}
	else
	{
		this->valueCounts[value - this->rangeFirst] ++;
	}
}

size_t Range::getCount(T value) const 
{
	if (value >= (this->rangeFirst + this->rangeLength))
	{
		return 0;
	}
	else
	{
		return this->valueCounts[value - this->rangeFirst];
	}
}

void Range::clear() 
{
	delete[] this->valueCounts;
	this->valueCounts = nullptr;
	this->rangeLength = 0;
}

void Range::resize(T first, T last)
{
	size_t* newArr = new size_t[last - first + 1]{};
	if (first < this->rangeFirst)
	{
		size_t startindex = this->rangeFirst - first;
		size_t afterlast = this->rangeFirst + this->rangeLength - first;
		auto c = 0;
		for (size_t i = startindex; i < afterlast; i++) {
			newArr[i] = this->valueCounts[c];
			c++;
		}
		delete[] this->valueCounts;
		this->valueCounts = newArr;
		newArr = nullptr;
	}
	else if (last >= this->rangeFirst + this->rangeLength) 
	{
		for (size_t i = 0; i < this->rangeLength; i++) 
		{
			newArr[i] = this->valueCounts[i];
		}
		delete[] this->valueCounts;
		this->valueCounts = newArr;
		newArr = nullptr;
	}
}

bool Range::empty() const 
{
	return this->rangeLength == 0;
}

Range::Range(const Range& other) 
{
	this->valueCounts = copyValues(other);
	this->rangeLength = other.rangeLength;
	this->rangeFirst = other.rangeFirst;
}

Range& Range::operator=(const Range& other) 
{
	if (this != &other)
	{
		if (this->rangeLength != 0)
		{
			delete[] this->valueCounts;
		}
		this->valueCounts = copyValues(other);
		this->rangeLength = other.rangeLength;
		this->rangeFirst = other.rangeFirst;
	}
	return *this;
}

Range::~Range() 
{
	delete[] this->valueCounts;
	this->valueCounts = nullptr;
}

size_t Range::getIndex(T value) const 
{
	return value - this->rangeFirst;
}