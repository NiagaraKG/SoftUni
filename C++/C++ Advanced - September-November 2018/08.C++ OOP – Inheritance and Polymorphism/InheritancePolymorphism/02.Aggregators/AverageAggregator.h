#ifndef AVERAGE_AGGREGATOR_H
#define AVERAGE_AGGREGATOR_H

#include "Aggregator.h"

#include <sstream>

class AverageAggregator : public StreamAggregator
{
	int curr;
	int br = 0;
public:
	AverageAggregator(std::istream& stream) : StreamAggregator(stream)
	{
		this->aggregationResult = 0;
		while (stream >> curr)
		{
			this->aggregationResult += curr;
			br++;
		}
		this->aggregationResult = this->aggregationResult / br;
	}
};

#endif // !AVERAGE_AGGREGATOR_H
