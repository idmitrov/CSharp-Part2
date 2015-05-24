using System.Linq;

namespace MatrixShuffling
{
    using System;

    class MatrixShuffling
    {
        static void Main()
        {

            string matrixSizes = Console.ReadLine();

            int matrixRows = int.Parse(matrixSizes.Split(' ')[0]),
                matrixCols = int.Parse(matrixSizes.Split(' ')[1]);

            //CREATE MATRIX
            string[,] matrix = new string[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < matrixCols; col++)
                {
                    string currentCell = currentLine.Split(' ')[col];
                    matrix[row, col] = currentCell;
                }
            }


            while (true)
            {
                //GE COMMAND
                string currentLine = Console.ReadLine();
     
                if (currentLine.Length >= 3 && currentLine.Substring(0, 3) == "END") break;
                else if (currentLine.Length >= 12 && currentLine.Contains(" ")
                        && currentLine.Split(' ').Length == 5 && currentLine.Substring(0, 4) == "swap")
                {
                    string[] positions = currentLine.Split(' ');
                    positions[0] = "0";

                    int tryParseOutput;
                    if (positions.All(position => int.TryParse(position, out tryParseOutput)))
                    {
                        int firstCellRow = int.Parse(positions[1]),
                            firstCellCol = int.Parse(positions[2]),
                            secondCellRow = int.Parse(positions[3]),
                            secondCellCol = int.Parse(positions[4]);

                        if (firstCellRow < matrixRows && firstCellCol < matrixCols
                            && secondCellRow < matrixRows && secondCellCol < matrixCols
                            && firstCellRow >= 0 && firstCellCol >= 0
                            && secondCellRow >= 0 && secondCellCol >= 0)
                        {
                            bool areCellsXYEqual = (firstCellRow == secondCellRow && firstCellCol == secondCellCol);


                            if (!areCellsXYEqual)
                            {
                                string firstCellValue = matrix[firstCellRow, firstCellCol],
                                   secondCellValue = matrix[secondCellRow, secondCellCol];

                                matrix[firstCellRow, firstCellCol] = secondCellValue;
                                matrix[secondCellRow, secondCellCol] = firstCellValue;
                            }

                            for (int row = 0; row < matrixRows; row++)
                            {
                                for (int col = 0; col < matrixCols; col++)
                                {
                                    Console.Write("{0, 5}", matrix[row, col]);
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
