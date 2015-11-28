using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class HeapRunner
    {
        public static void Run()
        {
            var inputArray = new[] {5, 3, 17, 10, 84, 19, 6, 22, 9};
            RunHeap("Building max heap recursive", Heap.BuildMaxHeapRecursive, inputArray);
            RunHeap("Building max heap interative", Heap.BuildMaxHeapIterative, inputArray);
        }

        private static void RunHeap(string name, Func<int[], int[]>buildHeap, int[] inputArray)
        {
            Utils.PrintAlgorithmRun(name, ()=>
            {
                Console.WriteLine($"{Utils.FormatArray(inputArray)} => ");
                var maxHeap = buildHeap(inputArray);
                Utils.PrintHeap(maxHeap);
            });
        }
    }
}