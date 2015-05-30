/*
    Write a program to find how many times a given string appears in a given text as substring. \
    The text is given at the first input line. The search string is given at the second input line. 
    The output is an integer number. 
    Please ignore the character casing. 
    Overlapping between occurrences is allowed. 
    
    Examples:
                INPUT           OUTPUT
                    
                aaaaaa          5 (a)

                ababa caba      3 (aba)
*/

namespace CountSubstringOccurrences
{
    using System;

    class CountSubstringOccurrences
    {
        static void Main()
        {
            //GET INPUT
            string text = Console.ReadLine(),
                   subText = Console.ReadLine();

            //IF INPUT IS NOT NULL
            if (text != null && subText != null)
            {
                //SET DEFAULT VALUE IF INPUT IS NOT NULL
                int countOccurrences = 0;

                //MAKE BOTH TO LOWERCASE
                text = text.ToLower();
                subText = subText.ToLower();

                //IF TEXT CONTAINS SUBTEXT
                if (text.Contains(subText))
                {
                    //GET SUBTEXT LENGTH
                    int subTextLength = subText.Length;

                    //WHILE TEXT CONTAINS SUBTEXT, CUT TEXT SUBTEXT OCCURRENCES
                    while (text.Contains(subText))
                    {
                        int occurrenceIndex = text.IndexOf(subText, StringComparison.Ordinal);
                        text = text.Substring(occurrenceIndex + subTextLength);
                        countOccurrences++;
                    }
                }

                //PRINT RESULT (OCCURRENCES)
                Console.WriteLine(countOccurrences);
            }
        }
    }
}
