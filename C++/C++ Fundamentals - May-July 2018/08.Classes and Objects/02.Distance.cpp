#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

// d = sqrt((x1-x2)^2 + (y1-y2)^2)

class Distance
{
public:
   double x1,y1,x2,y2;
   void Calculate(double x1,double y1,double x2,double y2)
   {
       double distance = sqrt(pow(x1-x2,2) + pow(y1-y2,2));
       cout << fixed << setprecision(3) << distance << endl;
   }
};

int main()
{
    double x1,y1,x2,y2;
    cin >> x1 >> y1 >> x2 >> y2;
    Distance Distance;
    Distance.Calculate(x1,y1,x2,y2);
    return 0;
}
