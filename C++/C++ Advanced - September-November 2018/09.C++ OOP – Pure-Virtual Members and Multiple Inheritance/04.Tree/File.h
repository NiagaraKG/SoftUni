#ifndef FILE_H
#define FILE_H

#include "FileSystemObject.h"
#include "ByteContainer.h"

#include<string>
#include <cstdlib>

class File : public FileSystemObject, public ByteContainer
{
	std::string bytes;
public:
	File(std::string name, std::string contents) : FileSystemObject(name), bytes(contents) {}

	size_t getSize() const override
	{
		return this->getBytes().size();
	}

	std::string getBytes() const override
	{
		return this->bytes;
	}
};

#endif