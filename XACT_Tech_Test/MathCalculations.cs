using System;
namespace XACT_Tech_Test
{
    public static class MathCalculations
    {

        // Less precise
        public static decimal GetDistanceShort(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            return (decimal)Math.Sqrt(Math.Pow(((double)x2 - (double)x1), 2) + Math.Pow(((double)y2 - (double)y1), 2));
        }

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

        /*
        public decimal CalculateDevotion(decimal _minimal, decimal _nominal)
        {
            decimal result = 0.0m;
            result = _nominal - _minimal;
            return result;
        }

        // More precise
        public decimal GetDistance(decimal x1, decimal y1, decimal x2, decimal y2)
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

        private decimal DecimalSqrt(decimal _value)
        {
            decimal root = _value / 3;
            int i;
            for (i = 0; i < 32; i++)
            {
                root = (root + _value / root) / 2;
            }

            return root;
        }
        */
    }
}

