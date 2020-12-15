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

        public static List<int[,]> findAllEmpty(int[,] board)
        {
            List<int[,]> emptyPositions = new List<int[,]>();
            for(int i=0; i<board.Length; i++)
            {
                for(int j=0; j<board.Length; j++)
                {
                    if (board[i, j] == 0)
                        emptyPositions.Add(new int[i, j]);
                }
            }
            return emptyPositions;
        }

    }
}
