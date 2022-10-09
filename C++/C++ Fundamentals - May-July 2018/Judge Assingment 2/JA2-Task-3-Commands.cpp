#include <iostream>
#include <stack>
#include <string>
#include <sstream>

using namespace std;

void Do_Operation(string operation, stack<int>& numbers)
{
	int result, num1, num2;
	if (operation == "sum")
	{
		num1 = numbers.top();
		numbers.pop();
		num2 = numbers.top();
		numbers.pop();
		result = num1 + num2;
		numbers.push(result);
	}
	else if (operation == "subtract")
	{
		num1 = numbers.top();
		numbers.pop();
		num2 = numbers.top();
		numbers.pop();
		result = num1 - num2;
		numbers.push(result);
	}
	else if (operation == "concat")
	{
		num1 = numbers.top();
		numbers.pop();
		num2 = numbers.top();
		numbers.pop();
		string concat = to_string(num2) + to_string(num1);
		istringstream resultIn(concat);
		resultIn >> result;
		numbers.push(result);
	}
	else if (operation == "discard")
	{
		numbers.pop();
	}
}

int main()
{
	int num;
	string operation;
	stack<int> numbers;
	stack<int> output_numbers;
	cin >> operation;
	while (operation != "end")
	{
		if (operation != "sum" && operation != "subtract" &&
			operation != "concat" && operation != "discard")
		{
			istringstream nin(operation);
			nin >> num;
			numbers.push(num);
		}
		else
		{
			Do_Operation(operation, numbers);
		}
		cin >> operation;
	}
	while (numbers.size() != 0)
	{
		num = numbers.top();
		numbers.pop();
		output_numbers.push(num);
	}
	while (output_numbers.size() != 0)
	{
		cout << output_numbers.top() << endl;
		output_numbers.pop();
	}
	return 0;
}
