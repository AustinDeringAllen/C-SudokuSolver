using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[,] board = {
                { 0, 0, 6, 0, 0, 5, 3, 0, 2 },
                { 0, 0, 0, 0, 0, 4, 7, 0, 0 },
                { 9, 0, 0, 3, 0, 0, 8, 6, 0 },
                { 0, 0, 0, 0, 0, 3, 0, 7, 0 },
                { 0, 0, 3, 0, 0, 0, 5, 0, 0 },
                { 0, 7, 0, 5, 0, 0, 0, 0, 0 },
                { 0, 2, 4, 0, 0, 7, 0, 0, 9 },
                { 0, 0, 1, 9, 0, 0, 0, 0, 0 },
                { 3, 0, 9, 8, 0, 0, 2, 0, 0 },
            };

            PrettifySudoku(board);
        }

        public static void Solve(int[,] board)
        {
            List<int[]> allEmptyPositions = FindAllEmpty(board);
            Dictionary<int, List<int>> impossibleNumbers = new Dictionary<int, List<int>>();
            for (int i = 0; i < allEmptyPositions.Count; i++)
            {
                impossibleNumbers.Add(i, new List<int>());
            }

            int key = 0;
            while(true)
            {
                int[] currentPosition = allEmptyPositions[key];
                int nextMove = findValidMove(board, currentPosition, impossibleNumbers[key]);

                if(nextMove != -1)
                {
                    key++;
                    board[currentPosition[0], currentPosition[1]] = nextMove;
                } else
                {
                    impossibleNumbers[key].Clear();
                    key--;
                    int[] previousPosition = allEmptyPositions[key];
                    impossibleNumbers[key].Add(board[previousPosition[0], previousPosition[1]]);
                    board[previousPosition[0], previousPosition[1]] = 0;
                }

                if (key == allEmptyPositions.Count)
                    break;
            }
        }

        public static int findValidMove(int[,] board, int[] currentPosition, List<int> impossibleNumbers)
        {
            for(int number=1; number<=board.Length; number++)
            {
                if (IsValidMove(board, currentPosition, number, impossibleNumbers))
                    return number;
            }
            return -1;
        }

        public static bool CheckRow(int[,] board, int[] currentPosition, int number, List<int> impossibleNumbers)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[currentPosition[0], i] == number)
                    return false;
            }
            return true;
        }

        public static bool CheckColumn(int[,] board, int[] currentPosition, int number, List<int> impossibleNumbers)
        {
            for(int i=0; i<board.Length; i++)
            {
                if (board[i, currentPosition[1]] == number)
                    return false;
            }
            return true;
        }

        public static bool CheckGrid(int[,] board, int[] currentPosition, int number, List<int> impossibleNumbers)
        {
            int[] newPosition = { currentPosition[0], currentPosition[1] };
            for(int i=0; i<newPosition.Length; i++)
            {
                switch(newPosition[i] % 3)
                {
                    case 0:
                        newPosition[i] += 1;
                        break;
                    case 2:
                        newPosition[i] -= 1;
                        break;
                }
            }

            for(int i=newPosition[0]-1; i<=newPosition[0]+1; i++)
            {
                for(int j=newPosition[1]-1; j<=newPosition[1]+1; j++)
                {
                    if (board[i, j] == number)
                        return false;
                }
            }
            return true;
        }

        public static bool IsValidMove(int[,] board, int[] currentPosition, int number, List<int> impossibleNumbers)
        {
            bool row, column, grid;

            if (impossibleNumbers.Contains(number))
                return false;

            row = CheckRow(board, currentPosition, number, impossibleNumbers);
            column = CheckColumn(board, currentPosition, number, impossibleNumbers);
            grid = CheckGrid(board, currentPosition, number, impossibleNumbers);

            return row && column && grid;
        }

        public static List<int[]> FindAllEmpty(int[,] board)
        {
            List<int[]> emptyPositions = new List<int[]>();
            for(int i=0; i<board.Length; i++)
            {
                for(int j=0; j<board.Length; j++)
                {
                    if (board[i, j] == 0)
                    {
                        int[] newPosition = { i, j };
                        emptyPositions.Add(newPosition);
                    }
                }
            }
            return emptyPositions;
        }


        // Needs a little work
        public static void PrettifySudoku(int[,] board)
        {
            Console.WriteLine("----------");
            for(int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    if (i == board.GetLength(0) - 1)
                        Console.WriteLine(board[i, j] + "\n");
                    else
                        Console.WriteLine(board[i, j]);
                }
            }
        }

    }
}
