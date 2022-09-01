#ifndef HAS_INFO
#define HAS_INFO

#include <string>

class HasInfo
{
public:
	virtual std::string getInfo() const = 0;
};

#endif
