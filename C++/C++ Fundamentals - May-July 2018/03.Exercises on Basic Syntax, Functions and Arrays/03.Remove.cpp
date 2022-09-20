#include <iostream>
#include <vector>

using namespace std;

vector<int> ReadArray()
{
    int Size, num;
    cin >> Size;
     vector<int> numbers;
     for(int i = 0; i < Size; i++)
        {
            cin >> num;
            numbers.push_back(num);
        }
        return numbers;
}

vector<int> RemoveArrayElements(vector<int> old_numbers, int remove_element)
{
    for(int i = 0; i < old_numbers.size(); i++)
        {
            if(remove_element == old_numbers[i])
            {
                 old_numbers.erase(old_numbers.begin() + i);
                 i--;
            }
        }
        return old_numbers;
}

int main()
{
    vector<int> numbers = ReadArray();
    int number_remove;
    cin >> number_remove;
    vector<int> new_numbers = RemoveArrayElements(numbers, number_remove);
     for(int i = 0; i < new_numbers.size(); i++)
        {
                cout << new_numbers[i] << " ";
        }
        cout << endl;
    return 0;
}
