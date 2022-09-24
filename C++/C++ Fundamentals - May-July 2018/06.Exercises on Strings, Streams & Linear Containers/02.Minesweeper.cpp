#include <iostream>
#include <vector>

using namespace std;

void Is_Mine(int row, int col, vector<vector<char> > minefield, int& Count)
{
    bool Valid_Position = row >= 0 && col >= 0 && row < minefield.size() && col < minefield[row].size();
     if( Valid_Position && minefield[row][col] == '!')
    {
        Count++;
    }
}

int Count_Mines(int row, int col, vector<vector<char> > minefield)
{
    int Count = 0;
    Is_Mine(row - 1, col - 1, minefield, Count);
    Is_Mine(row - 1, col, minefield, Count);
    Is_Mine(row - 1, col + 1, minefield, Count);
    Is_Mine(row, col - 1, minefield, Count);
    Is_Mine(row, col, minefield, Count);
    Is_Mine(row, col + 1, minefield, Count);
    Is_Mine(row + 1, col - 1, minefield, Count);
    Is_Mine(row + 1, col, minefield, Count);
    Is_Mine(row + 1, col + 1, minefield, Count);
    return Count;
}

int main()
{
    int rows, cols;
    cin >> rows >> cols;
    vector< vector<char> > minefield;
    for(int row = 0; row < rows; row++)
    {
        vector<char> current_row;
        for(int col = 0; col < cols; col++)
        {
            char cell;
            cin >> cell;
            current_row.push_back(cell);
        }
        minefield.push_back(current_row);
    }
    vector<vector<int> > mine_counts;
    for(int row = 0; row < rows; row++)
    {
        vector<int> current_row;
        for(int col = 0; col < cols; col++)
        {
            int cell;
            cell = Count_Mines(row, col, minefield);
            current_row.push_back(cell);
        }
        mine_counts.push_back(current_row);
    }
    for(int row = 0; row < rows; row++)
    {
        for(int col = 0; col < cols; col++)
        {
            cout << mine_counts[row][col];
        }
        cout << endl;
    }
    return 0;
}
