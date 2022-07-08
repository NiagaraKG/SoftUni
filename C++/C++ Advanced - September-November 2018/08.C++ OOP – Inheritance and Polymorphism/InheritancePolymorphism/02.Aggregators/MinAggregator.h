#ifndef MIN_AGGREGATOR_H
#define MIN_AGGREGATOR_H

#include "Aggregator.h"

#include <sstream>

class MinAggregator : public StreamAggregator
{
	int curr;
public:
	MinAggregator(std::istream& stream) : StreamAggregator(stream)
	{
		stream >> curr;
		this->aggregationResult = curr;
		while (stream >> curr)
		{
			if (this->aggregationResult > curr)
			{
				this->aggregationResult = curr;
			}
		}
	}
};

#endif // !MIN_AGGREGATOR_H

