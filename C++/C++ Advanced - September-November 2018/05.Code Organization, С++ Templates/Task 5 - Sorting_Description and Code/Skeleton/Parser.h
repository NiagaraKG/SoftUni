#ifndef PARSER_H
#define PARSER_H

#include <string>
#include <sstream>

template<typename T>
class Parser
{
	std::istream& input;
	std::string stopLine;

public:
	Parser(std::istream& input, std::string& stopLine) : input(input), stopLine(stopLine) {}

	bool readNext(T& toParse)
	{
	    std::string line;
		std::getline(this->input, line);
		if (line == this->stopLine)
		{
			return false;
		}
        std::istringstream In(line);
        In >> toParse;
		return true;
	}
};

#endif
