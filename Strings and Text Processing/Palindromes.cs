/*
    Write a program that extracts from a given text all palindromes,
    e.g. ABBA, lamal, exe and prints them on the console 
    on a single line, separated by comma and space. 
    Use spaces, commas, dots, question marks and exclamation marks as word delimiters. 
    Print only unique palindromes, sorted lexicographically.
    
    Example:
                    INPUT                                   OUTPUT

                    Hi,exe? ABBA! Hog fully a string. Bob   a, ABBA, exe
*/

namespace Palindromes
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                var unicePalindromesSortedSet = new SortedSet<string>();

                string[] words = input
                    .Split(new[] { '.', ',', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    char[] tempChar = word.ToCharArray();
                    Array.Reverse(tempChar);
                    string wordReversed = String.Join("", tempChar);

                    if (word == wordReversed)
                    {
                        unicePalindromesSortedSet.Add(word);
                    }
                }

                Console.Write("{0} \r\n\r\n", String.Join(", ", unicePalindromesSortedSet));
            }
        }
    }
}
