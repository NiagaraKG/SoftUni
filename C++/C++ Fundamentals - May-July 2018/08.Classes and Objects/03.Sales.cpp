#include <iostream>
#include<map>
#include <iomanip>
#include <string>
#include <vector>

using namespace std;

class Sale
{
public:
	string town;
	string product;
	double price;
	double quantity;

};

int main()
{
	vector<Sale> sales;
	map<string, double> sums;
	int n;
	cin >> n;
	while (n != 0)
	{
		Sale current;
		cin >> current.town;
		cin >> current.product;
		cin >> current.price;
		cin >> current.quantity;
		sales.push_back(current);
		sums[current.town];
		n--;
	}
	for (pair<string,double> t : sums)
	{
		for (Sale i : sales)
		{
			if (t.first == i.town)
			{
				t.second = t.second + i.price * i.quantity;
			}
		}
		cout << t.first << " -> " << fixed << setprecision(2) << t.second << endl;
	}
	return 0;
}
