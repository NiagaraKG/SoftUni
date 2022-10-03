#include <iostream>
#include <map>
#include <string>
#include <vector>

using namespace std;

int main()
{
	map<string, double> resources;
	string curr_resource;
	double curr_quantity;
	vector<string> sequence;
	getline(cin, curr_resource);
	while (curr_resource != "stop")
	{
	    //get resource order below
	    bool repeat = false;
             for(string word : sequence)
             {
                 if (curr_resource == word)
                 {
                     repeat = true;
                     break;
                 }
             }
             if(!repeat)
             {
                 sequence.push_back(curr_resource);
             }
        //get resource order above
		cin >> curr_quantity;
		resources[curr_resource] += curr_quantity;
		cin.ignore();
		getline(cin, curr_resource);
	}
	for (int i = 0; i < sequence.size(); i++)
	{
		cout << sequence[i] << " -> " << resources[sequence[i]] << endl;
	}
	return 0;
}
