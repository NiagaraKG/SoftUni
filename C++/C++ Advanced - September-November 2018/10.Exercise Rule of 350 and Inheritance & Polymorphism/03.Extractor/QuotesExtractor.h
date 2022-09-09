#ifndef QUOTES_EXTRACTOR_H
#define QUOTES_EXTRACTOR_H



class QuotesExtractor : public BufferedExtractor
{
	int numQuotes = 0;
protected:

	bool shouldBuffer(char symbol) override
	{
		if (symbol == '"')
		{
			numQuotes++;
			return false;
		}
		if (numQuotes % 2 == 0)
		{
			return false;
		}
		return true;
	}

public:
	QuotesExtractor(std::istream& stream) : BufferedExtractor(stream) {}
};

#endif
