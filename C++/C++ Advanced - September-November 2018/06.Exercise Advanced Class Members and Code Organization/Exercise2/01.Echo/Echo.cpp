#include "Echo.h"

#include <iostream>
#include <string>

bool echoOn;

void echo(const std::string& text)
{
	if (echoOn)
	{
		std::cout << text << std::endl;
	}
}