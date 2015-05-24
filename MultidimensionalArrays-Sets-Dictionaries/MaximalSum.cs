/*
    Write a program that reads a rectangular integer matrix of size N x M 
    and finds in it the square 3 x 3 that has maximal sum of its elements. 
    On the first line, you will receive the rows N and columns M. 
    On the next N lines you will receive each row with its columns.
    Print the elements of the 3 x 3 square as a matrix, along with their sum.
*/

namespace MaximalSum
{
    using System;

    public class MaximalSum
    {
        public static void Main()
        {
            //NOTICE CHECKS ARE NOT INCLUDED, EXPECTED INPUT IS VALID

            //GET MATRIX ROWS/COLS
            int matrixRows = 0, 
                matrixCols = 0;

            while (true)
            {
                string matrixSizes = Console.ReadLine();

                matrixRows = int.Parse(matrixSizes.Split(' ')[0]);
                matrixCols = int.Parse(matrixSizes.Split(' ')[1]);

                if (matrixRows >= 3 && matrixCols >= 3) break;
            }
            
            //CREATE MATRIX
            int[,] matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < matrixCols; col++)
                {
                    int currentCell = int.Parse(currentLine.Split(' ')[col]);
                    matrix[row, col] = currentCell;
                }
            }

            //SUM MATRIX 3x3
            int sum = 0;

            int[,] matrix3X3 = new int[3, 3];

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    if (row + 2 >= matrixRows || col + 2 >= matrixCols) break;
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                          + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                          + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > sum)
                    {
                        sum = currentSum;

                        matrix3X3[0, 0] = matrix[row, col];
                        matrix3X3[0, 1] = matrix[row, col + 1];
                        matrix3X3[0, 2] = matrix[row, col + 2];

                        matrix3X3[1, 0] = matrix[row + 1, col];
                        matrix3X3[1, 1] = matrix[row + 1, col + 1];
                        matrix3X3[1, 2] = matrix[row + 1, col + 2];

                        matrix3X3[2, 0] = matrix[row + 2, col];
                        matrix3X3[2, 1] = matrix[row + 2, col + 1];
                        matrix3X3[2, 2] = matrix[row + 2, col + 2];
                    }
                }
            }
            Console.WriteLine("Sum = {0}", sum);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write("{0, 5}", matrix3X3[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
