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
        public static int[,] CreateMatrix(int colCount, int rowCount, string pattern = "A")
        {
            int[,] matrix = new int[colCount, rowCount];

            int oddRowCellValue = 1,
                evenRowCellValueStart = 1;
            int test = 1;

            if (pattern == "A")
            {
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        matrix[col, row] = oddRowCellValue++;
                    }
                }
            }
            else if (pattern == "B")
            {
                int evenRowCellValue = 0;

                for (int col = 0; col < rowCount; col++)
                {
                    for (int row = 0; row < colCount; row++)
                    {
                        if (col % 2 != 0)
                        {
                            if (row == 0)
                            {
                                evenRowCellValueStart += colCount - 1;
                                evenRowCellValue = evenRowCellValueStart;
                                evenRowCellValueStart++;
                            }
                           
                            matrix[row, col] = evenRowCellValue;
                            evenRowCellValue--;
                        }
                        else
                        {
                            matrix[row, col] = oddRowCellValue;
                            evenRowCellValueStart++;
                        }
                        oddRowCellValue++;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Expected patter parameter to be A or B");
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

            //ASK FOR INPUT WHILE PARSE SUCCESS AND IS VALID INPUT
            do
            {
                //OUTPUT VALIDATION
                int colCount, rowCount;

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
                        Console.Clear();
                        Console.WriteLine("Expected number greater than 0.");
                        isValidInput = false;
                    }
                    else
                    {
                        //CREATE MATRIX PATTERN A
                        int[,] matrixA = CreateMatrix(colCount, rowCount);
                        //CREATE MATRIX PATTERN B
                        int[,] matrixB = CreateMatrix(colCount, rowCount, "B");

                        //PRINT MATRIX PATTERN A
                        Console.WriteLine("\r\nPattern A");
                        PrintMatrix(matrixA, colCount, rowCount);

                        //PRINT MATRIX PATTERN B
                        Console.WriteLine("\r\nPattern B");
                        PrintMatrix(matrixB, colCount, rowCount);
                    }
                }
                //PARSE NOT SUCCESS
                else
                {
                    isValidInput = false;
                    Console.Clear();
                    Console.WriteLine("Input must containg only valid integer numbers.");
                }
            } while (!isValidInput);
        }
    }
}
