#ifndef DIRECTORY_H
#define DIRECTORY_H

#include "FileSystemObjectsContainer.h"
#include "FileSystemObject.h"

#include<string>
#include <vector>
#include <memory>

class Directory : public FileSystemObject, public FileSystemObjectsContainer
{
	std::vector<std::shared_ptr<FileSystemObject> > nested;
public:
	Directory(std::string name) : FileSystemObject(name) {}

	size_t getSize() const override
	{
		size_t size = 0;
		for (auto ptr : this->nested)
		{
			size += ptr->getSize();
		}

		return size;
	}

	void add(const std::shared_ptr<FileSystemObject>& obj) override
	{
		this->nested.push_back(obj);
	}

	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator begin() const override
	{
		return this->nested.begin();
	}

	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator end() const override
	{
		return this->nested.end();
	}
};

#endif
