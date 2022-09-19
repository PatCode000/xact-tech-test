/// Author: Patryk Stachowiak

using System;
namespace XACT_Tech_Test
{
    /// <summary>
    /// Class <c>MathCalculations</c> is responsible for making math calculations.
    /// </summary>
    public static class MathCalculations
    {
        /// <summary>
        /// Method <c>GetDistanceDouble</c> get the distance between to points.
        /// Method use double data type so is less precise.
        /// </summary>
        /// <param name="x1"> x position of the first point.</param>
        /// <param name="y1"> y position of the first point.</param>
        /// <param name="x2"> x position of the second point.</param>
        /// <param name="y2"> y position of the second point.</param>
        public static decimal GetDistanceDouble(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal result = (decimal)Math.Sqrt(Math.Pow(((double)x2 - (double)x1), 2) + Math.Pow(((double)y2 - (double)y1), 2));
            //Console.WriteLine("DISTANCE RESULT: " + result);
            return result;
        }

        /// <summary>
        /// Method <c>GetDistance</c> get the distance between to points.
        /// Method use decimal data type so is more precise.
        /// </summary>
        /// <param name="x1"> x position of the first point.</param>
        /// <param name="y1"> y position of the first point.</param>
        /// <param name="x2"> x position of the second point.</param>
        /// <param name="y2"> y position of the second point.</param>
        public static decimal GetDistance(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal result = 0.0m;

            decimal deltaX = x2 - x1;
            decimal deltaXPow = deltaX * deltaX;

            decimal deltaY = y1 - y2;
            decimal deltaYPow = deltaY * deltaY;

            decimal powResult = deltaXPow + deltaYPow;

            result = DecimalSqrt(powResult);

            return result;
        }

        /// <summary>
        /// Method <c>DecimalSqrt</c> returns a square root of decimal number.
        /// </summary>
        /// <param name="_value"> decimal number.</param>
        private static decimal DecimalSqrt(decimal _value)
        {
            if (_value <= 0) return 0.0m;

            decimal root = _value / 3;
            int i;
            for (i = 0; i < 32; i++)
            {
                root = (root + _value / root) / 2;
            }

            return root;
        }

        /// <summary>
        /// Method <c>GetMinimum</c> returns the smallest number from the list.
        /// </summary>
        /// <param name="_values"> list of the values</param>
        public static decimal GetMinimum(List<decimal> _values)
        {
            decimal result = 10.0m;
            foreach (decimal value in _values)
            {
                if (value < result)
                {
                    result = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Method <c>GetMaximum</c> returns the biggest number from the list.
        /// </summary>
        /// <param name="_values"> list of the values</param>
        public static decimal GetMaximum(List<decimal> _values)
        {
            decimal result = 0.0m;
            foreach (decimal value in _values)
            {
                if (value > result)
                {
                    result = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Method <c>GetMean</c> returns the mean value from the list.
        /// </summary>
        /// <param name="_values"> list of the values</param>
        public static decimal GetMean(List<decimal> _values)
        {
            decimal average = 0.0m;
            decimal sum = 0.0m;
            foreach (decimal value in _values)
            {
                sum += value;
            }
            average = sum / _values.Count;
            return average;
        }

        /// <summary>
        /// Method <c>GetMediana</c> returns the mediana from the list.
        /// </summary>
        /// <param name="_values"> list of the values</param>
        public static decimal GetMediana(List<decimal> _values)
        {
            decimal[] sortedValues = InsertionSort(_values.ToArray());
            decimal mediana = 0.0m;

            if (sortedValues.Length%2 == 0)
            {
                mediana = ((sortedValues[sortedValues.Length / 2] + sortedValues[(sortedValues.Length / 2) + 1]) / 2);
            } else
            {
                int t_index = (int) ((13 / 2) + 1);
                mediana = (sortedValues[t_index]);
            }

            return mediana;
        }

        /// <summary>
        /// Method <c>InsertionSort</c> returns sorted array.
        /// </summary>
        /// <param name="_input"> array of the values</param>
        private static decimal[] InsertionSort(decimal[] _input)
        {
            decimal[] input = _input;
            for (int i = 0; i < input.Count(); i++)
            {
                var item = input[i];
                var currentIndex = i;

                while (currentIndex > 0 && input[currentIndex - 1] > item)
                {
                    input[currentIndex] = input[currentIndex - 1];
                    currentIndex--;
                }

                input[currentIndex] = item;
            }
            return input;
        }

        /// <summary>
        /// Method <c>CalculateDevotion</c> returns the difference between two numbers.
        /// </summary>
        /// <param name="_minimal"> first value</param>
        /// <param name="_nominal"> second value</param>
        public static decimal CalculateDevotion(decimal _minimal, decimal _nominal)
        {
            decimal result = 0.0m;
            result = _nominal - _minimal;
            return result;
        }

    }
}

