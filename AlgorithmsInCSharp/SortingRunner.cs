using System;
using AlgorithmsInCSharp.Algorithms.Sorting;

namespace AlgorithmsInCSharp
{
    internal static class SortingRunner
    {
        public static void Run()
        {
            RunSort("Insertion Sort", InsertionSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Selection Sort", SelectionSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Merge Sort", MergeSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Heap Sort", HeapSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Quick Sort", QuickSort.Sort, new[] { 5, 2, 4, 6, 1, 3 });
            RunSort("Counting Sort", QuickSort.Sort, new [] { -5, 12, 3, -7, 4, 4, 9});
        }

        private static void RunSort(string name, Action<int[]> sort, int[] inputArray)
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
