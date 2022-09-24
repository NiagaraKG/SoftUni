#include <iostream>
#include <string>
#include <sstream>

using namespace std;

int Tramslate_to(string num_to_translate, string num_system)
{
    int translated_num = 0;
    for(char symbol : num_to_translate)
    {
        int number = num_system.find(symbol);
        translated_num = translated_num * 10 + number;
    }
    return translated_num;
}

string toString(int n)
{
    ostringstream result;
    result << n;
    return result.str();
}

string Translate_from(int num, string num_system)
{
    ostringstream numOut;
    for(char symbol : toString(num))
    {
        int number = symbol - '0';
        char translated = num_system[number];
        numOut << translated;
    }
    return numOut.str();
}

int main()
{
   string num_system;
   string num1, num2;
   getline(cin,num_system);
   cin >> num1 >> num2;
   int sum = Tramslate_to(num1, num_system) + Tramslate_to(num2, num_system);
    cout << Translate_from(sum, num_system) << endl;
    return 0;
}
