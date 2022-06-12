#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <map>
#include <memory>

struct Range {
     const int from;
     const int to;

    Range(int from, int to)
    : from(from)
    , to(to) {}
};

bool inARange(int number,
    const std::map<int, std::shared_ptr<Range> >& byFrom,
    const std::map<int, std::shared_ptr<Range> >& byTo) {

    auto fromIter = byFrom.upper_bound(number);
    if(fromIter == byFrom.begin()) {
        return false;
    }
    fromIter--;
    auto toIter = byTo.lower_bound(number);
    if(toIter == byTo.end()) {
        return false;
    }
    return fromIter->second == toIter->second;
}
int main() {
    using namespace std;

    cin.sync_with_stdio(false);
    cout.sync_with_stdio(false);

    map<int, shared_ptr<Range> > rangesByFrom;
    map<int, shared_ptr<Range> > rangesByTo;

    string line;
    while(getline(cin, line) && line != ".") {
        istringstream lineIn(line);
        int from, to;
        lineIn >> from >> to;
        shared_ptr<Range> r = make_shared<Range>(from, to);
        rangesByFrom[r->from] = r;
        rangesByTo[r->to] = r;
    }
    ostringstream Output;
    while(getline(cin, line) && line != ".") {
        istringstream lineIn(line);
        int number;
        lineIn >> number;
        if(inARange(number, rangesByFrom, rangesByTo)){
            Output << "in\n";
        }
        else {
            Output << "out\n";
        }
    }
    cout << Output.str();
    return 0;
}
