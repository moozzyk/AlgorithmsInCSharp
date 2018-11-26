using System;

namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class CountingSort
    {
        public static void Sort(int[] array)
        {
            var maxValue = int.MinValue;
            var minValue = int.MaxValue;

            for (var i = 0; i < array.Length; i++)
            {
                minValue = Math.Min(minValue, array[i]);
                maxValue = Math.Max(maxValue, array[i]);
            }

            var result = Sort(array, minValue, maxValue, v => v);
            Array.Copy(result, array, array.Length);
        }
        public static int[] Sort(int[] array, int minKeyValue, int maxKeyValue, Func<int, int> key)
        {
            var tmp = new int[1 + maxKeyValue - minKeyValue];

            for (var i = 0; i < array.Length; i++)
            {
                tmp[key(array[i]) - minKeyValue]++;
            }

            for (var i = 1; i < tmp.Length; i++)
            {
                tmp[i] += tmp[i - 1];
            }

            var resultArray = new int[array.Length];

            for (var i = array.Length - 1; i >= 0; i--)
            {
                // `- 1` - because the array is 0 based
                resultArray[tmp[key(array[i]) - minKeyValue] - 1] = array[i];
                tmp[key(array[i]) - minKeyValue]--;
            }

            return resultArray;
        }
    }
}