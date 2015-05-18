/*
    Write a method that checks if 
    the element at given position in a given array of integers
    is larger than its two neighbours (when such exist).
*/

namespace LargerThanNeighbours
{
    using System;

    class LargerThanNeighbours
    {
        public static bool IsLargerThanNeighbours(int[] colectoin , int index)
        {
            if (colectoin.Length < 1 || index < 0 || index > colectoin.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0 || index == colectoin.Length - 1)
            {
                if (index == 0)
                {
                    return colectoin[index] > colectoin[1];
                }
                else
                {
                    return colectoin[index] > colectoin[colectoin.Length - 2];
                }
            }
            else
            {
                return colectoin[index] > colectoin[index - 1] && index > colectoin[index + 1];
            }
        }

        static void Main()
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }
        }
    }
}
