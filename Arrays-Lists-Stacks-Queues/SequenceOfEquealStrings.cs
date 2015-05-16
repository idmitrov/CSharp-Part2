/*
    Write a program that reads an array of strings and finds in it all sequences of equal elements 
    (comparison should be case-sensitive). 
    The input strings are given as a single line, separated by a space. 
    Examples:

    Input                   Output
    hi yes yes yes bye      hi
                            yes yes yes
                            bye
*/

using System;
using System.Collections.Generic;

namespace SequenceOfEquealStrings
{
    class SequenceOfEquealStrings
    {
        public static Dictionary<string, string> CheckReapetingWords(string[] input)
        {
            var words = new Dictionary<string, string>();

            foreach (string word in input)
            {
                //IF WORDS DOES NOT CONTAIN WORD (WORD IS NOT REPEATED)
                if (!words.ContainsKey(word))
                {
                    //ADD THE WORD IN WORDS
                    words.Add(word, word);
                }
                //ELSE WORDS CONTAIN THE WORD (IS REPEATED)
                else
                {
                    //ADD INTERVAL AND AGAIN THE WORD
                    words[word] += " " + word;
                }
            }

            return words;
        }

        //MAIN
        static void Main()
        {
            bool isValidInput;
            string strInput;

            //WHILE INPUT IS EMPTY OR NULL ASK AGAIN
            do
            {
                Console.Write("Type: ");
                //GET INPUT
                strInput = Console.ReadLine();
                isValidInput = true;
                //IF IS NULL OR EMPTY, INPUT IS NOT VALID
                if (string.IsNullOrEmpty(strInput))
                {
                    isValidInput = false;
                    Console.Clear();
                    Console.WriteLine("Input must not be empty.{0}", Environment.NewLine);
                  
                }

            } while (!isValidInput);

            if (strInput != null)
            {
                string[] input = strInput.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
                //GET WORDS AND REPEATING WORDS COUNT/VALUE
                var words = CheckReapetingWords(input);
            
                //PRINT AS RESULT ALL VALUES
                foreach (var word in words.Values)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
