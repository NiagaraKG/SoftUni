#include "IndexedSet.h"

IndexedSet::IndexedSet() { valuesArray = nullptr; }

IndexedSet::IndexedSet(const IndexedSet& other)
{
	this->valuesSet = other.valuesSet;
	this->valuesArray = new Value[other.valuesSet.size()];
	int i = 0;
	for (Value val : other.valuesSet)
	{
		valuesArray[i] = val;
		i++;
	}
}

void IndexedSet::add(const Value& v)
{
	this->valuesSet.insert(v);
	delete[] this->valuesArray;
	this->valuesArray = nullptr;
}

size_t IndexedSet::size() const
{
	return this->valuesSet.size();
}

const Value& IndexedSet::operator[](size_t index)
{
	if (this->valuesArray == nullptr)
	{
		this->valuesArray = new Value[this->valuesSet.size()];
		int i = 0;
		for (Value v : valuesSet)
		{
			this->valuesArray[i] = v;
			i++;
		}
	}

	return this->valuesArray[index];
}

IndexedSet& IndexedSet::operator=(const IndexedSet& other)
{
	if (this != &other)
	{
		this->valuesSet = other.valuesSet;
		this->valuesArray = new Value[other.valuesSet.size()];

		int i = 0;
		for (Value v : valuesSet)
		{
			this->valuesArray[i] = v;
			i++;
		}
	}

	return *this;
}

void IndexedSet::buildIndex()
{

}

void IndexedSet::clearIndex()
{

}


IndexedSet::~IndexedSet()
{
	delete[] this->valuesArray;
	this->valuesArray = nullptr;
}