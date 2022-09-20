#include <iostream>

using namespace std;

int main()
{
    int num1, num2, result;
	char operation;
	cin >> num1 >> num2;
	bool is_not_operator = true;
	while(is_not_operator)
    {
        cin >> operation;
        if (operation == '*')
        {
            result = num1 * num2;
            cout << result << endl;
            is_not_operator = false;
        }
        else if (operation == '/')
        {
            result = num1 / num2;
            cout << result << endl;
            is_not_operator = false;
        }
        else if (operation == '+')
        {
            result = num1 + num2;
            cout << result << endl;
            is_not_operator = false;
        }
        else if (operation == '-')
        {
            result = num1 - num2;
            cout << result << endl;
            is_not_operator = false;
        }
        else
        {
            cout << "try again" << endl;
        }
	}
	return 0;
}
