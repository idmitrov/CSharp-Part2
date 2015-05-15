/*
    Write a program to sort an array of numbers and then print them back on the console.
    The numbers should be entered from the console on a single line, separated by a space.
    Refer to the examples for problem 1.
    Note: Do not use the built-in sorting method, you should write your own.
    Use the selection sort algorithm. 
    Hint: To understand the sorting process better you may use a visual aid, e.g. Visualgo.
*/

using System;
using System.Linq;

namespace SortArrayOfNumbersImplementSort
{
    class ImplementSort
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

        //SORT NUMBERS
        public static void SortNumbers(int[] numbers)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int leftElement = numbers[i],
                        rightElement = numbers[i + 1];

                    if (leftElement > rightElement)
                    {
                        int tempElement = leftElement;

                        numbers[i] = rightElement;
                        numbers[i + 1] = tempElement;

                        swapped = true;
                    }
                }

            } while (swapped);
        }

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
                var input = strInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


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
                    SortNumbers(numbers);
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