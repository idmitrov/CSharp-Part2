/*
    Write a program that reads from the console a string of maximum 20 characters.
    If the length of the string is less than 20, the rest of the characters should be filled with *. 
    Print the resulting string on the console.
    
    Examples:
                INPUT                               OUTPUT
                
                Welcome to SoftUni!                 Welcome to SoftUni!*
                
                C#                                  C#******************
                
                a regular expression                a regular expression
                (abbreviated regex or
                regexp and sometimes called
                a rational expression) is a 
                sequence of characters that 
                forms a search pattern
*/

namespace StringLength
{
    using System;

    class StringLength
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                Console.WriteLine(input.Length < 20 
                    ? input.PadRight(20, '*') 
                    : input.Substring(0, 20));
            }
        }
    }
}
