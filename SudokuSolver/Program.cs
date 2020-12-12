using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[,] board = new int[,] {
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
            for(int i=0; i<board.Length; i++)
            {
                if (board[i, currentPosition[1]] == number)
                    return false;
            }
            return true;
        }

    }
}
