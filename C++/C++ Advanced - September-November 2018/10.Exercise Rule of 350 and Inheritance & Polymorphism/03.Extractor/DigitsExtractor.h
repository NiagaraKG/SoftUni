#ifndef DIGITS_EXTRACTOR
#define DIGITS_EXTRACTOR

#include "Extractor.h"

#include <cctype>

class DigitsExtractor : public Extractor
{
protected:
	bool process(char symbol, std::string& output) override
	{
		if (isdigit(symbol))
		{
			output = symbol;
			return true;
		}
		else
		{
			return false;
		}
	}

public:
	DigitsExtractor(std::istream& stream) : Extractor(stream) {}

};

#endif
