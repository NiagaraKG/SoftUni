#ifndef BYTE_CONTAINER
#define BYTE_CONTAINER

#include <string>

class ByteContainer
{
public:
	virtual std::string getBytes() const = 0;

	virtual ~ByteContainer() {}
};

#endif
