#include <iostream>
#include <string>

using namespace std;

int main()
{
	string input;
	cin >> input;
	bool used['z'+1]{};
	for (char letter : input)
	{
        used[letter] = true;
    }
	for (char letter = 'a'; letter <= 'z'; letter++)
	{
	    if(!used[letter])
        {
            cout << letter;
        }
	}
	cout << endl;
	return 0;
}
