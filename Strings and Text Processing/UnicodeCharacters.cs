/*
    Write a program that converts a string to a sequence of C# Unicode character literals.
    
    Examples:
                INPUT           OUTPUT

                Hi!             \0057\0068\0061\0074\003f\0021\003f
                What?!?         \0057\0068\0061\0074\003f\0021\003f
                SoftUni         \0053\006f\0066\0074\0055\006e\0069
*/

namespace UnicodeCharacters
{
    using System;

    class UnicodeCharacters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                Console.Clear();
                foreach (var symbol in input)
                {
                    Console.Write("\\u{0:x4}", (int)symbol);
                }
                Console.WriteLine("\r\n");
            }
        }
    }
}
