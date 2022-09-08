#ifndef EXTRACTOR_INITIALIZATION_H
#define EXTRACTOR_INITIALIZATION_H

#include "Extractor.h"
#include "DigitsExtractor.h"
#include "NumbersExtractor.h"
#include "QuotesExtractor.h"

#include <string>
#include <istream>
#include <memory>

	std::shared_ptr<Extractor> getExtractor(const std::string& extractType, std::istream& stream)
	{
		if (extractType == "digits")
		{
			return std::make_shared<DigitsExtractor>(stream);
		}
		if (extractType == "numbers")
		{
			return std::make_shared<NumbersExtractor>(stream);
		}
		if (extractType == "quotes")
		{
			return std::make_shared<QuotesExtractor>(stream);
		}
		return nullptr;
	}

#endif
