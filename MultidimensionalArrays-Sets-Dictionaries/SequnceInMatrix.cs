/*
    We are given a matrix of strings of size N x M. 
    Sequences in the matrix we define as sets of several neighbour elements
    located on the same line, column or diagonal.
    Write a program that finds the longest sequence of equal strings in the matrix.
    
    Examples:
                ha      fifi    ho  hi  ||  s   qq  s
                fo      ha      hi  xx  ||  pp  pp  s
                xxx     ho      xa  xxx ||  pp  qq  s
                Longest: ha, ha, ha     ||  Longest: s, s, s
*/

namespace SequnceInMatrix
{
    using System;
    using System.Collections.Generic;

    class SequnceInMatrix
    {
        static void Main()
        {
            //MATRIX DIMENSION
            Console.Write("Number of rows: ");
            int matrixRows = int.Parse(Console.ReadLine());
            Console.Write("Number of columns: ");
            int matrixCols = int.Parse(Console.ReadLine());
            //Clear console
            Console.Clear();

            //CREATE MATRIX
            string[,] matrix = new string[matrixRows, matrixCols];

            //FILL MATRIX
            for (int row = 0; row < matrixRows; row++)
            {
                Console.WriteLine("Type row {0} -> comumns values, separated by space", row);
                //GET CURRENT ROW -> COLUMNS
                string currentLine = Console.ReadLine();

                for (int col = 0; col < matrixCols; col++)
                {
                    string currentCell = currentLine.Split(' ')[col];
                    matrix[row, col] = currentCell;
                }
            }

            //INIT LONGEST SEQUENCE
            var longestSequence = new List<string>();

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    //COLS
                    if (col + 1 < matrixCols)
                    {
                        if (matrix[row, col] == matrix[row, col + 1])
                        {
                            var tempSequence = new List<string>();
                            //FROM FIRST REPEATING COL CELL TO THE LAST REPEATING COL CELL...
                            for (int currentCol = col; currentCol < matrixCols; currentCol++)
                            {
                                if (matrix[row, col] == matrix[row, currentCol])
                                {
                                    tempSequence.Add(matrix[row, currentCol]);
                                }
                                else
                                {
                                    col += tempSequence.Count;
                                    break;
                                }
                            }

                            //IF TEMP SEQUENCE IS LONGER THAN LONGEST SEQUENCE
                            if (tempSequence.Count > longestSequence.Count)
                            {
                                longestSequence = tempSequence;
                            }
                        }
                    }
                    //END OF CHECK
                }
            }

            //ROWS
            for (int col = 0; col < matrixCols; col++)
            {
                for (int row = 0; row < matrixRows; row++)
                {
                    if (row + 1 < matrixRows)
                    {
                        if (matrix[row, col] == matrix[row + 1, col])
                        {
                            var tempList = new List<string>();
                            //FROM FIRST REPEATING ROW CELL TO THE LAST REPEATING ROW CELL...
                            for (int currentRow = row; currentRow < matrixRows; currentRow++)
                            {
                                if (matrix[row, col] == matrix[currentRow, col])
                                {
                                    tempList.Add(matrix[currentRow, col]);
                                }
                                else
                                {
                                    row += tempList.Count;
                                    break;
                                }
                            }

                            //IF TEMP SEQUENCE IS LONGER THAN LONGEST SEQUENCE
                            if (tempList.Count > longestSequence.Count)
                            {
                                longestSequence = tempList;
                            }
                        }
                    }
                }
            }
            
            //DIAGONAL
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    int nextRow = row + 1,
                        nextCol = col + 1;

                    //FROM FIRST DIAGONAL CELL TO THE LAST DIAGONAL CELL...
                    if (nextRow < matrixRows && nextCol < matrixCols)
                    {
                        var tempSequence = new List<string>();

                        if (matrix[row, col] == matrix[nextRow, nextCol])
                        {
                            tempSequence.Add(matrix[row, col]);
                            while (true)
                            {
                                if (nextRow >= matrixRows || nextCol >= matrixCols) break;
                                if (matrix[row, col] != matrix[nextRow, nextCol]) break;
                                tempSequence.Add(matrix[nextRow, nextCol]);
                                nextRow++;
                                nextCol++;
                            }
                        }

                        //IF TEMP SEQUENCE IS LONGER THAN LONGEST SEQUENCE
                        if (tempSequence.Count > longestSequence.Count)
                        {
                            longestSequence = tempSequence;
                        }
                    }
                }
            }

            //CLEAR
            Console.Clear();
            //IF SEQUENCES FOUND
            if (longestSequence.Count > 0)
            {
                //PRINT LONGEST SEQUENCE
                Console.WriteLine("Longest sequence: {0}", string.Join(", ", longestSequence));
            }
            //ELSE NO SEQUENCES
            else
            {
                Console.WriteLine("No sequences found");
            }
        }
    }
}
