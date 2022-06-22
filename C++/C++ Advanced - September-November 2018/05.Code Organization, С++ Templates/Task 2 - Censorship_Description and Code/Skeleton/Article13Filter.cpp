#include "Article13Filter.h"

#include <string>
#include <sstream>
#include <set>

Article13Filter::Article13Filter(std::set<std::string> copyrighted) : copyrighted(copyrighted){};

bool Article13Filter::isCopyrighted(std::string s)
{
    return this->copyrighted.find(s) != this->copyrighted.end();
}

bool Article13Filter::blockIfCopyrighted(std::string s)
{
    if(isCopyrighted(s))
    {
        this->blocked.push_back(s);
        return true;
    }
}

std::vector<std::string> Article13Filter::getBlocked()
{
    return this->blocked;
}
