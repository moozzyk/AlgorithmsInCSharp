using System;
using AlgorithmsInCSharp.Algorithms.Misc;

namespace AlgorithmsInCSharp
{
    internal static class MiscAlgorithmsRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("QuickSelect", RunQuickSelect);
            Utils.PrintAlgorithmRun("DutchFlag", RunDutchFlag);
            Utils.PrintAlgorithmRun("ArrayRotation", RunArrayRotation);
        }

        private static void RunQuickSelect()
        {
            var inputArray = new[] { 5, 8, 7, 2, 6, 3, 9 };
            Console.WriteLine($"{Utils.FormatArray(inputArray)}");
            Console.WriteLine($"Min: {QuickSelect.Select(inputArray, 0)}");
            Console.WriteLine($"Max: {QuickSelect.Select(inputArray, inputArray.Length - 1)}");
            Console.WriteLine($"4th smallest (0 based): {QuickSelect.Select(inputArray, 4)}");
        }

        private static void RunDutchFlag()
        {
            var inputArray = new[] { 2, 5, 8, 4, 4, 7, 1, 2, 6, 3, 9 };
            int pivotIdx = 4;
            Console.WriteLine($"Input: {Utils.FormatArray(inputArray)}, pivot: {inputArray[pivotIdx]}");
            DutchFlag.Partition(inputArray, pivotIdx);
            Console.WriteLine($"{Utils.FormatArray(inputArray)}");
        }

        private static void RunArrayRotation()
        {
            var inputArray = new[] { 1, 2, 3, 4, 5, 6 };
            var positions = 2;
            Console.WriteLine($"Input: {Utils.FormatArray(inputArray)}, rotate by: {positions}");
            var arrayCopy = (int[])inputArray.Clone();
            ArrayRotation.Rotate(arrayCopy, positions);
            Console.WriteLine($"Rotate: {Utils.FormatArray(arrayCopy)}");

            arrayCopy = (int[])inputArray.Clone();
            ArrayRotation.Rotate_Reverse(arrayCopy, positions);
            Console.WriteLine($"Rotate by using array reverse: {Utils.FormatArray(arrayCopy)}");
        }
    }
}