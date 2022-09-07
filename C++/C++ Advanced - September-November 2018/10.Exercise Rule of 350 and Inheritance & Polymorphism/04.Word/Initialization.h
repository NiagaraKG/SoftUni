#ifndef INITIALIZATION_H
#define INITIALIZATION_H

#include "CommandInterface.h"

#include <memory>
#include <string>

class CutTransform : public TextTransform
{
	std::shared_ptr<std::string> clipboard;
public:

	CutTransform(std::shared_ptr<std::string> clipboard) : clipboard(clipboard) {}

	void invokeOn(std::string& text, int startIndex, int endIndex) override
	{
		int lenght = endIndex - startIndex;
		*clipboard = text.substr(startIndex, lenght);
		text.erase(startIndex, lenght);
	}
};

class PasteTransform : public TextTransform
{
	std::shared_ptr<std::string> clipboard;
public:

	PasteTransform(std::shared_ptr<std::string> clipboard) : clipboard(clipboard) {}

	void invokeOn(std::string& text, int startIndex, int endIndex) override
	{
		text.replace(startIndex, endIndex - startIndex, *clipboard);
	}
};

class ExtendedCommandInterface : public CommandInterface
{
public:
	ExtendedCommandInterface(std::string& text) : CommandInterface(text) {}

protected:
	std::vector<Command> initCommands() override
	{
		std::vector<Command> commands = CommandInterface::initCommands();
		auto clipboard = std::make_shared<std::string>();
		commands.push_back(Command("cut", std::make_shared<CutTransform>(clipboard)));
		commands.push_back(Command("paste", std::make_shared<PasteTransform>(clipboard)));
		return commands;
	}
};

std::shared_ptr<CommandInterface> buildCommandInterface(std::string& text)
{
	auto commandInerface = std::make_shared<ExtendedCommandInterface>(text);
	commandInerface->init();
	return commandInerface;
}

#endif
