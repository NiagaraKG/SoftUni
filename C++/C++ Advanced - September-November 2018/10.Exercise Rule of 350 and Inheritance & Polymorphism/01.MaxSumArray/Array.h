#ifndef ARRAY_H
#define ARRAY_H

#include<cstdlib>

template<typename T>
class Array
{
	T* data;
	size_t size;

public:
	Array(size_t size) : data(new T[size]), size(size) {}

	size_t getSize() const
	{
		return this->size;
	}

	T& operator[](size_t index)
	{
		return this->data[index];
	}

	T* begin()
	{
		return this->data;
	}

	T* end()
	{
		return this->data + this->size;
	}

	friend void swap(Array<T>& a, Array<T>& b)
	{
		using std::swap;
		swap(a.data, b.data);
		swap(a.size, b.size);
	}

	~Array()
	{
		delete[] this->data;
		this->data = nullptr;
	}

	Array(const Array<T>& other) : Array(other.size)
	{
		for (size_t i = 0; i < other.size; i++)
		{
			this->data[i] = other.data[i];
		}
	}

	Array<T>& operator=(Array<T> copy)
	{	
		swap(*this, copy);
		return *this;
	}
};

#endif
