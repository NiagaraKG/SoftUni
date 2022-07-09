#ifndef SUM_AGGREGATOR_H
#define SUM_AGGREGATOR_H

#include "Aggregator.h"

#include <sstream>

class SumAggregator : public StreamAggregator
{
	int curr;
public:
	SumAggregator(std::istream& stream) : StreamAggregator(stream)
	{
		this->aggregationResult = 0;
		while (stream >> curr)
		{
			this->aggregationResult += curr;
		}
	}
};

#endif // !SUM_AGGREGATOR_H
