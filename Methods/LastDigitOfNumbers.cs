/*
    Write a method that returns the last digit of a given integer as an English word.
    Test the method with different input values. Ensure you name the method properly.

    Examples: 
                Input                                               Output

                Console.WriteLine(GetLastDigitAsWord(512));         Two
                Console.WriteLine(GetLastDigitAsWord(1024));        Four
                Console.WriteLine(GetLastDigitAsWord(12309));       Nine
*/

namespace LastDigitOfNumbers
{
    using System;

    class LastDigitOfNumbers
    {
        public static string GetLastDigitAsWord(int number)
        {
            int lastDigitOfNumber = number % 10;

            switch (lastDigitOfNumber)
            {
                case 0: return "Zero";
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                default: return "Invalid input";
            }
        }

        static void Main()
        {
            Console.WriteLine(GetLastDigitAsWord(512));
            Console.WriteLine(GetLastDigitAsWord(1024));
            Console.WriteLine(GetLastDigitAsWord(12309));
        }
    }
}
