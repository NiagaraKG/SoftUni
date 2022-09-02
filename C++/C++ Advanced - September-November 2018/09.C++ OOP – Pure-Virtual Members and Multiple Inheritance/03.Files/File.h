#ifndef FILE_H
#define FILE_H

#include "FileSystemObject.h"
#include "ByteContainer.h"

#include<string>

class File : public FileSystemObject, public ByteContainer
{
	std::string bytes;
public:
	File(std::string name, std::string contents) : FileSystemObject(name), bytes(contents) {}

	virtual size_t getSize() const
	{
		return this->bytes.size();
	}

	std::string getBytes()
	{
		return this->bytes;
	}
};

#endif
