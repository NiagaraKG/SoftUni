#include <iostream>

using namespace std;

int main()
{
   int row, col, num;
     cin >> row >> col;
   int matrix[row][col];
   bool is_found = false;
   for(int i = 0; i < row; i++)
   {
       for(int a = 0; a < col; a++)
        {
            cin >> matrix[i][a];
        }
   }
   cin >> num;
   for(int i = 0; i < row; i++)
   {
       for(int a = 0; a < col; a++)
        {
            if(matrix[i][a] == num)
            {
                cout << i << " " << a << endl;
                is_found = true;
            }
        }
   }
   if(!is_found)
   {
       cout << "not found" << endl;
   }
    return 0;
}
