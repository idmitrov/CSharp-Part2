/*
    Write a program to read an array of numbers from the console, 
    sort them and print them back on the console. 
    The numbers should be entered from the console on a single line, separated by a space.
            
    Examples:   Input	                Output
                6 5 4 10 -3 120 4       -3 4 4 5 6 10 120
                10 9 8                  8 9 10

*/

using System;
using System.Linq;

namespace SortArrayOfNumbers
{
    class SortArrayOfNumbers
    {
        //VALIDATE INPUT
        public static bool ValidateInput(string[] input)
        {
            int output;

            return input.All(index => int.TryParse(index, out output));
        }

        //PRINT ERROR MESSAGE
        public static void PrintInvalidInput(string[] input)
        {
            if (input.Length < 1)
            {
                Console.WriteLine("Input must not be empty!");
            }
            else
            {
                Console.WriteLine(
                    "The numbers should be entered from the console {0}" +
                    "on a single line, separated by a space.{0}" +
                    "Notice: Allowed only valid integer numbers.{0}",
                    Environment.NewLine
                    );
            }
        }

        //MAIN
        static void Main()
        {
            bool isValidInput = true;
        
            //ASK FOR INPUT WHILE PARSE SUCCESS
            do
            {
                Console.Write("Type: ");
                string strInput = Console.ReadLine();
                if (strInput == null) continue;

                //GET INPUT FROM CONSOLE AND SPLIT IT BY SPACE
                string[] input = strInput.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                //IS VALID IF CONTAIN INTEGER NUMBERS AND IS NOT EMPTY
                isValidInput = ValidateInput(input) && input.Length > 0;
            
                //IF INPUT IS NOT VALID, PRINT ERROR MESSAGE
                if (!isValidInput)
                {
                    Console.Clear();
                    PrintInvalidInput(input);
                }
                //ELSE INPUT IS VALID, CONTINUE
                else
                {
                    //PARSE INPUT FROM STRINGS TO INTEGERS
                    int[] numbers = Array.ConvertAll(input, int.Parse);
                    //SORT INPUTS
                    Array.Sort(numbers);
                    //PRINT INPUTS
                    foreach (int number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                }
            } while (!isValidInput);
        }
    }
}
