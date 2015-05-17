/*
    Write a program to find all increasing sequences inside an array of integers. 
    The integers are given on a single line, separated by a space. \
    Print the sequences in the order of their appearance in the input array, each at a single line.
    Separate the sequence elements by a space. 
    Find also the longest increasing sequence and print it at the last line. 
    If several sequences have the same longest length, print the left-most of them. 
    
    Examples:
    
                Input                       Output
                2 3 4 1 50 2 3 4 5          2 3 4
                                            1 50
                                            2 3 4 5
                                            Longest: 2 3 4 5
*/

using System;
using System.Linq;

namespace LongestIncreasingSequence
{
    class LongestIncreasingSequence
    {
        //VALIDATE INPUT
        public static bool ValidateInput(string input)
        {
            int tempOutput;
            if (input == null || input.Trim().Length < 1)
            {
                return false;
            }

            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .All(number => int.TryParse(number, out tempOutput));
        }

        //PRINT ERROR MESSAGE
        public static void PrintErrorMessage(string input)
        {
            Console.Clear();
            Console.WriteLine(input.Trim().Length < 1 ?
                "Input can not be empty.\r\n" :
                "Input must contain only valid integer numbers\r\n");
        }

        //FIND LONGEST SEQUENCE
        public static string FindLongestSequence(int[] numbers)
        {
            int numbersLength = numbers.Length;
            string longestSequence = String.Empty;

            for (int i = 0; i < numbersLength; i++)
            {
                string tempString = numbers[i].ToString();
                int currentNumber = numbers[i];

                for (int j = i + 1; j < numbersLength; j++)
                {
                    //GET CURRENT NUMBER AND NEXT NUMBER
                    int nextNumber = numbers[j];

                    //IF SEQUENCE INCREASE (CURRENT < NEXT)
                    if (nextNumber > currentNumber)
                    {
                        currentNumber = nextNumber;
                        i++;
                        tempString += " " + currentNumber;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine(tempString);

                if (tempString.Replace("-", "").Length > longestSequence.Length)
                {
                    longestSequence = tempString;
                }
            }
            return longestSequence;
        }

        //MAIN
        private static void Main()
        {
            bool isValidInput;
            string strInput;
            //ASK FOR INPUT WHILE PARSE SUCCESS
            do
            {
                Console.Write("Type: ");
                //GET INPUT FROM CONSOLE
                strInput = Console.ReadLine();

                //VALIDATE INPUT
                isValidInput = ValidateInput(strInput);

                //IF INPUT IS NOT VALID PRINT ERROR MESSAGE
                if (!isValidInput)
                {
                    PrintErrorMessage(strInput);
                }

            } while (!isValidInput);

            //SPLIT INPUT
            string[] input = strInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //PARSE INPUT
            int[] numbers = Array.ConvertAll(input, int.Parse);
            //FIND LONGEST SEQUENCE
            string longestSequence = FindLongestSequence(numbers);
            //PRINT RESULT
            Console.WriteLine("Longest: {0}", longestSequence);
        }
    }
}
