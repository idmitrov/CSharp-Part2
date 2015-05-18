/*
    Write a method GetMax() with two parameters 
    that returns the larger of two integers. 
    Write a program that reads 2 integers from the console
    and prints the largest of them using the method GetMax().
*/

namespace BiggerNumber
{
    using System;

    class BiggerNumber
    {
        public static int GetMax(int firstNumber, int secondNumber)
        {
            return firstNumber > secondNumber ? firstNumber : secondNumber;
        }

        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine()),
                secondNumber = int.Parse(Console.ReadLine());

            int max = GetMax(firstNumber, secondNumber);
            Console.WriteLine(max);
        }
    }
}
