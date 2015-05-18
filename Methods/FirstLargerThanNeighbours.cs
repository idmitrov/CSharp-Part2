/*
    Write a method that returns the index of the first element in array
    that is larger than its neighbours, or -1 if there's no such element.
    Use the method from the previous exercise in order to re.
*/

namespace FirstLargerThanNeighbours
{
    using System;

    class FirstLargerThanNeighbours
    {
        public static int GetIndexOfFirstElementLargerThanNeighbours(int[] colectoin)
        {
            if (colectoin.Length > 0)
            {
                for (int i = 0; i < colectoin.Length; i++)
                {
                    if (i != 0 && i != colectoin.Length - 1)
                    {
                        if (colectoin[i] > colectoin[i - 1] &&
                            colectoin[i] > colectoin[i + 1])
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (colectoin[i] > colectoin[i + 1])
                            {
                                return i;
                            }
                        }
                        else
                        {
                            if (colectoin[i] > colectoin[i - 1])
                            {
                                return i;
                            }
                        }
                    }
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
            int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
            int[] sequenceThree = { 1, 1, 1 };

            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));

            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));

            Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
        }
    }
}
