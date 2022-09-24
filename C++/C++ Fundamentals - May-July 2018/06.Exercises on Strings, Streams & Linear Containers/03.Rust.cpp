#include <iostream>
#include <queue>

//// BREADTH-FIRST SEARCH

/******************
struct Cell
{ int row; int col; };

Cell a;
a.row = 1;
a.col = 3;
******************/


using namespace std;

const int ROWS = 10;
const int COLS = 10;

void printMatrix(char matrix[ROWS][COLS])
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

bool canInfectCell(int row, int col, char matrix[ROWS][COLS])
{
	return (row >= 0 && col >= 0 && row < ROWS && col < COLS && matrix[row][col] == '.');
}


void InfectIfPossible(int row, int col, int currentTime, char matrix[ROWS][COLS], queue<int>& nextRow, queue<int>& nextCol, queue<int>& nextTime)
{
	if (canInfectCell(row, col, matrix))
	{
		matrix[row][col] = '!';
		nextRow.push(row);
		nextCol.push(col);
		nextTime.push(currentTime + 1);
	}
}

void spreadRust(int rustRow, int rustCol, char matrix[ROWS][COLS], int time)
{
	queue<int> nextRow;
	queue<int> nextCol;
	queue<int> nextTime;
	nextRow.push(rustRow);
	nextCol.push(rustCol);
	nextTime.push(0);
	while (!nextRow.empty())
	{
		int currentRow = nextRow.front();
		int currentCol = nextCol.front();
		int currentTime = nextTime.front();
		nextRow.pop();
		nextCol.pop();
		nextTime.pop();
		if (currentTime < time)
		{
			InfectIfPossible(currentRow - 1, currentCol, currentTime, matrix, nextRow, nextCol, nextTime);
			InfectIfPossible(currentRow, currentCol + 1, currentTime, matrix, nextRow, nextCol, nextTime);
			InfectIfPossible(currentRow + 1, currentCol, currentTime, matrix, nextRow, nextCol, nextTime);
			InfectIfPossible(currentRow, currentCol - 1, currentTime, matrix, nextRow, nextCol, nextTime);
		}
	}
}

int main()
{
	int time, rustCol, rustRow;
	char metalMatrix[ROWS][COLS];
	for (int r = 0; r < ROWS; r++)
	{
		for (int c = 0; c < COLS; c++)
		{
			char currentCell;
			cin >> currentCell;
			metalMatrix[r][c] = currentCell;
			if (currentCell == '!')
			{
				rustRow = r;
				rustCol = c;
			}
		}
	}
	cin >> time;
	spreadRust(rustRow, rustCol, metalMatrix, time);
	printMatrix(metalMatrix);
	return 0;
}
