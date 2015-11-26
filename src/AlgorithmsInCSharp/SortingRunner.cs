using System;
using AlgorithmsInCSharp.Algorithms.Sorting;

namespace AlgorithmsInCSharp
{
    internal static class SortingRunner
    {
        public static void Run()
        {
            RunSort("Insertion Sort", InsertionSort.Sort, new[]{ 5, 2, 4, 6, 1, 3 });
            RunSort("Selection Sort", SelectionSort.Sort, new[]{ 5, 2, 4, 6, 1, 3 });
            RunSort("Merge Sort", MergeSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Heap Sort", HeapSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Quick Sort", QuickSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Counting Sort", QuickSort.Sort, new[] { -5, 12, 3, -7, 4, 4, 9 });
            RunSort("Radix Sort", RadixSort.Sort, new[] { 329, 1042, 457, 657, 20, 839, 436, 720, 355 });
            RunSort("Bucket Sort", BucketSort.Sort, new double[] { 0.78, 0.17, 0.39, 0.26, 0.72, 0.94, 0.21, 0.12, 0.23, 0.68 });
        }

        private static void RunSort<T>(string name, Action<T[]> sort, T[] inputArray)
        {
            Utils.PrintAlgorithmRun(name, () =>
                {
                    Console.Write($"{Utils.FormatArray(inputArray)} => ");
                    sort(inputArray);
                    Console.WriteLine(Utils.FormatArray(inputArray));
                });
        }
    }
}
