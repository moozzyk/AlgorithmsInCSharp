using System;

namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class CountingSort
    {
        public static int[] Sort(int[] array)
        {
            var maxValue = int.MinValue;
            var minValue = int.MaxValue;

            for (var i = 0; i < array.Length; i++)
            {
                minValue = Math.Min(minValue, array[i]);
                maxValue = Math.Max(maxValue, array[i]);
            }

            var tmp = new int[1 + maxValue - minValue];

            for (var i = 0; i < array.Length; i++)
            {
                tmp[array[i] - minValue]++;
            }

            for (int i = 0, runningSum = 0; i < tmp.Length; i++)
            {
                runningSum += tmp[i];
                tmp[i] = runningSum;
            }

            var resultArray = new int[array.Length];

            for (var i = array.Length - 1; i >= 0; i--)
            {
                // `- 1` - because the array is 0 based
                resultArray[tmp[array[i] - minValue] - 1] = array[i];
                tmp[array[i] - minValue]--;
            }

            return resultArray;
        }
    }
}