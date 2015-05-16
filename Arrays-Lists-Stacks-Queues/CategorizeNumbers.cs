/*
    Write a program that reads N floating-point numbers from the console.
    Your task is to separate them in two sets,
    one containing only the round numbers (e.g. 1, 1.00, etc.) 
    and the other containing the floating-point numbers with non-zero fraction. 
    Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places).
    
    Examples:       input                                       Output
                    1.2 -4 5.00 12211 93.003 4 2.2              [1.2, 93.003, 2.2] -> min: 1.2, max: 93.003, sum: 96.403, avg: 32.13
                                                                [-4, 5, 12211, 4] - > min: -4, max: 12211, sum: 12216, avg: 3054.00
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CategorizeNumbersAndFindMinMaxAvg
{
    class CategorizeNumbers
    {
        public static bool ValidateInput(string[] input)
        {
            double output;
            
            return  input.All(index => double.TryParse(index, out output));
        }

        //CATEGORIZE NUMBERS
        public static void CategorizeNumber(double[] numbers, List<double> ZeroFractionNumbers, List<double> nonZeroFractionNumbers)
        {
            foreach (var number in numbers)
            {
                if (number % 1 == 0)
                {
                    ZeroFractionNumbers.Add(number);
                }
                else
                {
                    nonZeroFractionNumbers.Add(number);
                }
            }
        }

        //PRINT ZERO FRACTION NUMBERS VALUES
        public static void PrintZeroFractionValues(List<double> zeroFractionNumbers)
        {
            string zeroFractionFormat = "[" + string.Join(" ", zeroFractionNumbers) + "]";

            Console.WriteLine("{0} -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}",
                zeroFractionFormat,
                zeroFractionNumbers.Min(),
                zeroFractionNumbers.Max(),
                zeroFractionNumbers.Sum(),
                Math.Round(zeroFractionNumbers.Sum() / zeroFractionNumbers.Count, 2)
            );
        }
        
        //PRINT NON ZERO FRACTION VALUES
        public static void PrintNonZeroFractionValues(List<double> nonZeroFractionNumbers)
        {
            string nonZeroFractionFormat = "[" + string.Join(" ", nonZeroFractionNumbers) + "]";

            Console.WriteLine("{0} -> min: {1}, max: {2}, sum: {3}, avg: {4:0.00}",
                nonZeroFractionFormat,
                nonZeroFractionNumbers.Min(),
                nonZeroFractionNumbers.Max(),
                nonZeroFractionNumbers.Sum(),
                Math.Round(nonZeroFractionNumbers.Sum() / nonZeroFractionNumbers.Count, 2)
            );
        }

        //PRINT INVALID INPUT
        public static void PrintInvalidInput(string[] input)
        {
            Console.WriteLine(input.Length < 1 ?
                "Input must not be empty." :
                "Please type only valid numbers, separated by space");
        }

        //MAIN
        static void Main()
        {
            //SETUP GLOBALIZATION
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            bool isValidInput = true;
           
            //ASK FOR INPUT WHILE PARSE SUCCESS
            do
            {
                Console.Write("Type: ");

                //GET INPUT FROM CONSOLE
                string strInput = Console.ReadLine();
                if (strInput != null)
                {
                    //SPLIT INPUT BY SPACE ' '
                    string[] input = strInput.Replace(',', '.').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //VALID INPUT = INPUTS IS VALIDATED AND IS NOT EMPTY
                    isValidInput = ValidateInput(input) & input.Length > 0;
                    
                    //IF INPUT IS VALID
                    if (isValidInput)
                    {
                        //PARSE ALL NUMBERS INTO ARRAY
                        double[] numbers = Array.ConvertAll(input, double.Parse);

                        //INIT LISTS FOR CATEGORIES
                        var nonZeroFractionNumbers = new List<double>();
                        var zeroFractionNumbers = new List<double>();

                        //CATEGORIZE NUMBERS INTO BOTH LISTss
                        CategorizeNumber(numbers, zeroFractionNumbers, nonZeroFractionNumbers);

                        //IF LIST IS NOT EMPTY GET MIN MAX AVG
                        if (nonZeroFractionNumbers.Count > 0)
                        {
                            //PRINT VALUES
                            PrintNonZeroFractionValues(nonZeroFractionNumbers);
                        }

                        //IF LIST IS NOT EMPTY GET MIN MAX AVG
                        if (zeroFractionNumbers.Count > 0)
                        {
                            //PRINT VALUES
                            PrintZeroFractionValues(zeroFractionNumbers);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        PrintInvalidInput(input);
                    }
                }
            } while (!isValidInput);
        }
    }
}
