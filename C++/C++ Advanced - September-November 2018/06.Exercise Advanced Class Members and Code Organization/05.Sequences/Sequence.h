#ifndef SEQUENCE_H
#define SEQUENCE_H

#include <vector>

template<typename T, typename Generator>
class Sequence
{
public:
	class Iterator 
	{
		const std::vector<T>& elements;
		int index;

		Iterator(const std::vector<T>& elements, int index) : elements(elements), index(index) {}
	public:
		static Iterator getBegin(const std::vector<T>& elements) 
		{
			return Iterator(elements, 0);
		}

		static Iterator getEnd(const std::vector<T>& elements) 
		{
			return Iterator(elements, -1);
		}

		const T& operator*() const 
		{
			return this->elements[this->index];
		}

		Iterator& operator++() 
		{
			this->index++;
			return *this;
		}

		bool operator!=(const Iterator& other) const 
		{
			return !(*this == other);
		}

		bool operator==(const Iterator& other) const 
		{
			bool SameSequence = this->elements == other.elements;
			bool bothEnd = isEnd(this->index, this->elements) && isEnd(other.index, other.elements);
			bool SamePosition = this->index == other.index;
			return SameSequence && (bothEnd || SamePosition);
		}

	private:
		static int isEnd(int index, const std::vector<T>& elements) 
		{
			return index == -1 || index == elements.size();
		}
	};

private:
	Generator generator;
	std::vector<T> elements;
public:
	void generateNext(int n)
	{
		for (int i = 0; i < n; i++) {
			this->elements.push_back(this->generator());
		}
	}

	Iterator begin() const
	{
		return Iterator::getBegin(this->elements);
	}

	Iterator end() const 
	{
		return Iterator::getEnd(this->elements);
	}
};

#endif // !SEQUENCE_H
