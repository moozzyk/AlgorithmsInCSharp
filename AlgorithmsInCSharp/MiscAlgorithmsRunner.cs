using System;
using AlgorithmsInCSharp.Algorithms.Misc;

namespace AlgorithmsInCSharp
{
    internal static class MiscAlgorithmsRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("QuickSelect", RunQuickSelect);
        }

        private static void RunQuickSelect()
        {
            var inputArray = new[] { 5, 8, 7, 2, 6, 3, 9};
            Console.WriteLine($"{Utils.FormatArray(inputArray)}");
            Console.WriteLine($"Min: {QuickSelect.Select(inputArray, 0)}");
            Console.WriteLine($"Max: {QuickSelect.Select(inputArray, inputArray.Length - 1)}");
            Console.WriteLine($"4th smallest (0 based): {QuickSelect.Select(inputArray, 4)}");
        }
    }
}
