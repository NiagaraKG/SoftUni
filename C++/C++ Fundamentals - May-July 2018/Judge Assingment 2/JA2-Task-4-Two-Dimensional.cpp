#include <iostream>
#include <queue>
#include <vector>

using namespace std;

int ROWS, COLS;
char fillChar, startChar;

void printMatrix(vector<vector<char> >& matrix)
{
	for (int r = 0; r < ROWS; r++)
	{
		for (int c = 0; c < COLS; c++)
		{
			cout << matrix[r][c];
		}
		cout << endl;
	}
}

bool canChangeCell(int row, int col, vector<vector<char> >& matrix)
{
	return row >= 0 && col >= 0 && row < ROWS && col < COLS && matrix[row][col] == startChar;
}


void ChangeIfPossible(int row, int col, vector<vector<char> >& matrix, queue<int>& nextRow, queue<int>& nextCol)
{
	if (canChangeCell(row, col, matrix))
	{
		matrix[row][col] = fillChar;
		nextRow.push(row);
		nextCol.push(col);
	}
}

void Fill(int firstRow, int firstCol, vector<vector<char> >& matrix)
{
	queue<int> nextRow;
	queue<int> nextCol;
	nextRow.push(firstRow);
	nextCol.push(firstCol);
	int currentRow;
	int currentCol;
	while (!nextRow.empty())
	{
        currentRow = nextRow.front();
        currentCol = nextCol.front();
		nextRow.pop();
		nextCol.pop();
		ChangeIfPossible(currentRow - 1, currentCol, matrix, nextRow, nextCol);
		ChangeIfPossible(currentRow, currentCol + 1, matrix, nextRow, nextCol);
		ChangeIfPossible(currentRow + 1, currentCol, matrix, nextRow, nextCol);
		ChangeIfPossible(currentRow, currentCol - 1, matrix, nextRow, nextCol);
	}
	ChangeIfPossible(currentRow, currentCol, matrix, nextRow, nextCol);
}

int main()
{
	int startRow, startCol;
	vector<vector<char> > matrix;
	cin >> ROWS >> COLS;
	for (int r = 0; r < ROWS; r++)
	{
		vector<char> Row;
		for (int c = 0; c < COLS; c++)
		{
			char currentCell;
			cin >> currentCell;
			Row.push_back(currentCell);
		}
		matrix.push_back(Row);
	}
	cin >> fillChar;
	cin >> startRow >> startCol;
	startChar = matrix[startRow][startCol];
	Fill(startRow, startCol, matrix);
	printMatrix(matrix);
	return 0;
}
