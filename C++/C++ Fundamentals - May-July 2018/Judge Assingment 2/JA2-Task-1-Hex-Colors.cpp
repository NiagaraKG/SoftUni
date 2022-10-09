#include <iostream>
#include <string>
#include <sstream>

using namespace std;

int ToInt(char Color[2])
{
	int color, first, second;
	if (Color[0] < 'a')
	{
		first = Color[0] - '0';
	}
	else
	{
		first = 10 + Color[0] - 'a';
	}
	if (Color[1] < 'a')
	{
		second = Color[1] - '0';
	}
	else
	{
		second = 10 + Color[1] - 'a';
	}
	color = 16 * first + second;
	return color;
}

string ToHex(int number)
{
	int dig1 = number / 16;
	int dig2 = number - dig1 * 16;
	char first;
	char second;
	if (dig1 < 10)
	{
		first = dig1 + '0';
	}
	else
	{
		first = (char)(dig1 + 'a' - 10);
	}
	if (dig2 < 10)
	{
		second = dig2 + '0';
	}
	else
	{
		second = (char)(dig2 + 'a' - 10);
	}
	string color;
	color.push_back(first);
	color.push_back(second);
	return color;
}

int main()
{
	string first, second;
	cin >> first >> second;
	first.erase(0, 1);
	second.erase(0, 1);
	char R[2];
	char G[2];
	char B[2];
	istringstream ColorIn1(first);
	ColorIn1 >> R[0];
	ColorIn1 >> R[1];
	ColorIn1 >> G[0];
	ColorIn1 >> G[1];
	ColorIn1 >> B[0];
	ColorIn1 >> B[1];
	int R1 = ToInt(R);
	int G1 = ToInt(G);
	int B1 = ToInt(B);
	istringstream ColorIn2(second);
	ColorIn2 >> R[0];
	ColorIn2 >> R[1];
	ColorIn2 >> G[0];
	ColorIn2 >> G[1];
	ColorIn2 >> B[0];
	ColorIn2 >> B[1];
	int R2 = ToInt(R);
	int G2 = ToInt(G);
	int B2 = ToInt(B);
	int AR = (R1 + R2) / 2;
	int AG = (G1 + G2) / 2;
	int AB = (B1 + B2) / 2;
	string AvR = ToHex(AR);
	string AvG = ToHex(AG);
	string AvB = ToHex(AB);
	cout << "#" << AvR << AvG << AvB << endl;
	return 0;
}
