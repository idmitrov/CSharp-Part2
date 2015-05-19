/*
    Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers.
    Overload the methods to work with numbers of type double and decimal.
    Note: Do not use LINQ.

*/

namespace NumberCalculations
{
    using System;

    class NumberCalculations
    {
        //MIN
        public static double GetMinNumberFrom(double[] collection)
        {
            double minNumber = double.MaxValue;

            foreach (var number in collection)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }

        public static decimal GetMinNumberFrom(decimal[] collection)
        {
            decimal minNumber = Decimal.MaxValue;

            foreach (var number in collection)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }

        //MAX
        public static double GetMaxNumberFrom(double[] collection)
        {
            double maxNumber = double.MinValue;

            foreach (var number in collection)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            return maxNumber;
        }

        public static decimal GetMaxNumberFrom(decimal[] collection)
        {
            decimal maxNumber = Decimal.MinValue;

            foreach (var number in collection)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            return maxNumber;
        }

        //SUM
        public static double GetSumFrom(double[] collection)
        {
            double sum = 0;

            foreach (var number in collection)
            {
                sum += number;
            }

            return sum;
        }

        public static decimal GetSumFrom(decimal[] collection)
        {
            decimal sum = 0;

            foreach (var number in collection)
            {
                sum += number;
            }

            return sum;
        }

        //AVG
        public static double GetAvgFrom(double[] collection)
        {
            return GetSumFrom(collection) / collection.Length;
        }

        public static decimal GetAvgFrom(decimal[] collection)
        {
            return GetSumFrom(collection) / collection.Length;
        }

        //PRODUCT
        public static double GetProductFrom(double[] collection)
        {
            double product = 1;

            foreach (var number in collection)
            {
                product *= number;
            }

            return product;
        }

        public static decimal GetProductFrom(decimal[] collection)
        {
            decimal product = 1;

            foreach (var number in collection)
            {
                product *= number;
            }

            return product;
        }

        //MAIN
        static void Main()
        {
            decimal[] numbersDecimal = {-1.1M, 0.5M, 1.2M, 3.4M, 5.6M, 7.8M };
            double[] numbersDouble = { -1.1, 0.5, 1.2, 3.4, 5.6, 7.8 };

            //MIN
            Console.WriteLine("MIN Decimal: {0}", GetMinNumberFrom(numbersDecimal));
            Console.WriteLine("MIN Double: {0}{1}", GetMinNumberFrom(numbersDouble), Environment.NewLine);
            //MAX
            Console.WriteLine("MAX Decimal: {0}", GetMaxNumberFrom(numbersDecimal));
            Console.WriteLine("MAX Double: {0}{1}", GetMaxNumberFrom(numbersDouble), Environment.NewLine);
            //AVG
            Console.WriteLine("AVG Decimal: {0}", GetAvgFrom(numbersDecimal));
            Console.WriteLine("AVG Double: {0}{1}", GetAvgFrom(numbersDouble), Environment.NewLine);
            //SUM
            Console.WriteLine("SUM Decimal: {0}", GetSumFrom(numbersDecimal));
            Console.WriteLine("SUM Double: {0}{1}", GetSumFrom(numbersDouble), Environment.NewLine);
            //PRODUCT
            Console.WriteLine("PRODUCT Decimal: {0}", GetProductFrom(numbersDecimal));
            Console.WriteLine("PRODUCT Double: {0}{1}", GetProductFrom(numbersDouble), Environment.NewLine);
        }
    }
}
