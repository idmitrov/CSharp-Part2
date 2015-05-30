/*
    Write a program that takes a text and a string of banned words.
    All words included in the ban list should be replaced with asterisks "*", equal to the word's length.
    The entries in the ban list will be separated by a comma and space ", ".
    The ban list should be entered on the first input line and the text on the second input line.
    
    Example:
                INPUT                                       OUTPUT

                Linux, Windows                              It is not *****, it is GNU/*****. *****
                                                            is merely the kernel, while GNU adds the 
                It is not Linux, it is GNU/Linux.           functionality. Therefore we owe it to them
                Linux is merely the kernel,                 by calling the OS GNU/*****! Sincerely, a
                while GNU adds the functionality.           ******* client
                Therefore we owe it to them by
                calling the OS GNU/Linux! 
                Sincerely, a Windows client
*/

namespace TextFilter
{
    using System;

    class TextFilter
    {
        static void Main()
        {
            //GET BANNED WORDS AND TEXT FROM CONSOLE
            string input = Console.ReadLine(),
                   text = Console.ReadLine();

            if (input != null && text != null)
            {
                //SPLIT INPUT BY ", " TO BANNED WORDS ARRAY
                string[] bannedWords = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                //FOR EACH BANNED WORD IN BANNED WORDS
                foreach (var bannedWord in bannedWords)
                {
                    //STRING OF STARS "*******" LONG AS BANNED WORD LENGTH
                    string replacingPattern = new string('*', bannedWord.Length);

                    //REPLACE BANNED WORDS WHILE TEXT CONTAIN BANNED WORDSs
                    while (text.Contains(bannedWord))
                    {
                        text = text.Replace(bannedWord, replacingPattern);
                    }
                }

                //PRINT REPLACED TEXT (IF BANNED WORDS FOUND, ELSE JUST THE ORIGINAL TEXT)
                Console.WriteLine(text);
            }
        }
    }
}
