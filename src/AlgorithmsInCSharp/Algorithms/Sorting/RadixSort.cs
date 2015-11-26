using System;

namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class RadixSort
    {
        public static void Sort(int[] array)
        {
            for (var weight = 1; weight < 100000; weight *= 10)
            {
                var sorted = CountingSort.Sort(array, 0, 9, v => (v % (weight * 10)) / weight);
                Array.Copy(sorted, array, array.Length);
            }
        }
    }
}