#ifndef COMPARATORS_H
#define COMPARATORS_H

#include "Song.h"

template <typename T>
class LessThan
{
public:

    bool operator() (const T& a, const T& b)
    {
        return a < b;
    }
};
template<>
class LessThan<Song>
{
    public:
      bool operator()<Song> (const Song& a, const Song& b)
    {
        return a.getLengthSeconds() < b.getLengthSeconds();
    }
};


template <typename T, typename Comparator>
class Reverse
{
public:
    bool operator() (const T& a, const T& b) const
    {
        Comparator comp;
        bool comparedResult = comp(a,b);
        return !comparedResult;
    }
};

#endif
