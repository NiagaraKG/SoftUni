#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

class Object
{
public:
	string type, system, nickname;
	int position;
	double mass, radius;
};

Object Devide_Info(string input)
{
	Object current_object;
	istringstream In(input);
	getline(In, current_object.type, ':');
	getline(In, current_object.system, '-');
	current_object.system.erase(0, 1);
	In >> current_object.position;
	if(input.find('(') != std::string::npos)
	{
		getline(In, current_object.nickname, ')');
		current_object.nickname.erase(0, 2);
	}
	string mass;
	getline(In, mass, ',');
	mass.erase(0, 2);
	istringstream Mass(mass);
	Mass >> current_object.mass;
	string radius;
	getline(In, radius, '}');
	istringstream Radius(radius);
	Radius>> current_object.radius;
	return current_object;
}

int main()
{
	vector<string> Archieve;
	ifstream ArchieveIn("Astronomic_Archieve.txt");
	string current;
	while (getline(ArchieveIn, current))
	{
		Archieve.push_back(current);
	}
	string operation;
	cout << "Insert type operation: ";
	cin >> operation;
	cin.ignore();
	cout << "Insert info as in Example.txt: " << endl;
	if (operation == "insert")
	{
		string input_data;
		getline(cin, input_data);
		Object object = Devide_Info(input_data);
		bool not_found = true;
		for (int i = 0; i < Archieve.size(); i++)
		{
			Object change_object = Devide_Info(Archieve[i]);
			if (object.nickname == change_object.nickname)
			{
				Archieve[i].replace(Archieve[i].find(change_object.type), change_object.type.size(), object.type);
				Archieve[i].replace(Archieve[i].find(change_object.system), change_object.system.size(), object.system);
				not_found = false;
			}
		}
		if (not_found)
		{
			Archieve.push_back(input_data);
		}
		ofstream New_data("Astronomic_Archieve.txt");
		for(string archieve_object : Archieve)
		{
			New_data << archieve_object << endl;
		}
		cout << "Done! See Astronomic_Archieve.txt." << endl;
	}
	 else if (operation == "search")
	{
		 string search_name;
		 string input;
		 getline(cin, input);
		 istringstream In(input);
		 In >> search_name;
		 bool not_found = true;
		 for (int i = 0; i < Archieve.size(); i++)
		 {
			 Object current_object = Devide_Info(Archieve[i]);
			 if (search_name == current_object.system)
			 {
				 not_found = false;
				 cout << current_object.type << ": " << current_object.system << "-" << current_object.position << " ";
				 if (current_object.nickname != "")
				 {
					 cout << "( " << current_object.nickname << " ) ";
				 }
				 cout << "{ mass: " << current_object.mass << ", radius: " << current_object.radius << " }" << endl;
			 }
			 if (search_name == current_object.nickname)
			 {
				 not_found = false;
				 cout << current_object.type << ": " << current_object.system << "-" << current_object.position << " ";
				 if (current_object.nickname != "")
				 {
					 cout << "( " << current_object.nickname << " ) ";
				 }
				 cout << "{ mass: " << current_object.mass << ", radius: " << current_object.radius << " }" << endl;
			 }
		 }
		 if (not_found)
		 {
			 cout << "No object found." << endl;
		 }
	}
	else
	{
		cout << "Invalid operation." << endl;
	}
	return 0;
}
