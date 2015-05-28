/*
    Write a program that reads some text from the console
    and counts the occurrences of each character in it. 
    Print the results in alphabetical (lexicographical) order.
    

    Examples:   SoftUni rocks        : 1 time/s
                                    S: 1 time/s
                                    U: 1 time/s
                                    c: 1 time/s
                                    f: 1 time/s
                                    i: 1 time/s
                                    k: 1 time/s
                                    n: 1 time/s
                                    o: 2 time/s
                                    r: 1 time/s
                                    s: 1 time/s
                                    t: 1 time/s

*/

using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    using System;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            //READ TEXT FROM CONSOLE
            string text;

            do
            {
                Console.Write("Text: ");
                text = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Text must not be empty");
                }
            } while (string.IsNullOrWhiteSpace(text));


            //TEXT RESULT
            Console.WriteLine("Text: {0}", text);

            //SPLIT TEXT AND COUNT OCCURRENCES IN DICTIONARY
            var textSymbols = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!textSymbols.ContainsKey(symbol))
                {
                    textSymbols.Add(symbol, 1);
                }
                else
                {
                    textSymbols[symbol]++;
                }
            }

            foreach (var symbol in textSymbols.OrderBy(i => i.Key))
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
