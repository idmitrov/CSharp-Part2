/*
    Write a method that reverses the digits of a given floating-point number.
*/

using System.Globalization;
using System.Linq;
using System.Threading;

namespace ReverseNumber
{
    using System;

    class ReverseNumber
    {
        public static double GetReversedNumber(double number)
        {
            //USING FOR LOOP
            //string numberAsString = number.ToString(CultureInfo.InvariantCulture),
            //       numberReversed = String.Empty;
            //int numberAsStringLength = numberAsString.Length;

            //for (int i = numberAsStringLength -1; i > 0; i--)
            //{
            //    numberReversed += numberAsString[i];
            //}

            //return double.Parse(numberReversed);

            //USING LINQ
            return double.Parse(String.Join("", number.ToString(CultureInfo.InvariantCulture).Reverse().ToArray()));
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double reversed = GetReversedNumber(123.45);
            Console.WriteLine(reversed);
        }
    }
}
