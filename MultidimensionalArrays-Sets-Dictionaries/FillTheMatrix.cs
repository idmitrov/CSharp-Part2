/*
    Write two programs that fill and print a matrix of size N x N. 
    Filling a matrix in the regular pattern (top to bottom and left to right) is boring.
    Fill the matrix as described in both patterns below:
*/

namespace FillTheMatrix
{
    using System;

    class FillTheMatrix
    {
        public static int[,] CreateMatrix(int colCount, int rowCount)
        {
            int[,] matrix = new int[colCount, rowCount];

            int count = 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    matrix[col, row] = count++;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix, int colCount, int rowCount)
        {
            for (int row = 0; row < colCount; row++)
            {
                for (int col = 0; col < rowCount; col++)
                {
                    Console.Write("{0, 3} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }


        static void Main()
        {
            bool isValidInput;
            int colCount, rowCount = int.MinValue;

            do
            {
                //OUTPUT VALIDATION
                
                //COL INPUT
                Console.Write("Number of colums: ");
                string colInput = Console.ReadLine();
                //ROW INPUT
                Console.Write("Number of rows: ");
                string rowInput = Console.ReadLine();
                //IF PARSE SUCCESS
                if (int.TryParse(colInput, out colCount) &&
                    int.TryParse(rowInput, out rowCount))
                {
                    //SET DEFAULT VALUE
                    isValidInput = true;
                    //IF COL OR ROW IS LESS THAN 1
                    if (colCount < 1 || rowCount < 1)
                    {
                        Console.WriteLine("0 is not allowed.");
                        isValidInput = false;
                    }
                }
                //PARSE NOT SUCCESS
                else
                {
                    isValidInput = false;
                    Console.Clear();
                    Console.WriteLine("Input must containg only valid integer numbers.");
                }
            } while (!isValidInput || colCount < 1 || rowCount < 1);

            int[,] matrix = CreateMatrix(colCount, rowCount);

            PrintMatrix(matrix, colCount, rowCount);
        }
    }
}
