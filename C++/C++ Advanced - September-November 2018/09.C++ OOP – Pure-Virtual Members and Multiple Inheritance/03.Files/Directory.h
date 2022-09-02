#ifndef DIRECTORY_H
#define DIRECTORY_H

#include "FileSystemObjectsContainer.h"
#include "FileSystemObject.h"
#include "File.h"

#include<string>
#include <vector>

class Directory : public FileSystemObject, public FileSystemObjectsContainer
{
	size_t size = 0;
public:
	Directory(std::string name) : FileSystemObject(name) {}

	virtual size_t getSize() const
	{
		
		return this->size;
	}

	void add(const std::shared_ptr<FileSystemObject>& obj)
	{
		this->size += obj->getSize();
	}
};

#endif
