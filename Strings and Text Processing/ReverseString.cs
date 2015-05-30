/*
    Write a program that reads a string from the console,
    reverses it and prints the result back at the console.
    
    Example     
                INPUT       OUTPUT
                
                sample      elpmas
                24tvcoi92   29iocvt42

    Note: You are NOT allowed to use regular expressions.
*/

namespace ReverseString
{
    using System;

    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    int inputLength = input.Length;

                    for (int letter = inputLength - 1; letter >= 0; letter--)
                    {
                        Console.Write(input[letter]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
