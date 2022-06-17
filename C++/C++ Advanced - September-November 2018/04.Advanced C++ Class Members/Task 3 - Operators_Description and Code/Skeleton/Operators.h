#ifndef OPERATORS_H
#define OPERATORS_H

#include <ostream>
#include <vector>
#include <string>
#include <sstream>

using namespace std;

vector<string>& operator<< (vector <string>& lines, string line)
{
   lines.push_back(line);
   return lines;
}

string operator+(string text, int num)
{
    ostringstream N;
    N << text << num;
    return N.str();
}

ostream& operator<< (ostream& out, const vector<string>& Lines)
{
  for(auto i = 0; i < Lines.size(); i++)
  {
    out << Lines[i];
    if(i+1 != Lines.size())
    {
        out << endl;
    }
  }
  return out;
}

#endif // !OPERATORS_H
