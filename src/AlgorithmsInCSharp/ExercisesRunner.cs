using System;
using AlgorithmsInCSharp.Algorithms.Misc;
using AlgorithmsInCSharp.DataStructures;
using AlgorithmsInCSharp.Exercises;

namespace AlgorithmsInCSharp
{
    internal static class ExercisesRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("SortStack", RunSortStack);
        }

        private static void RunSortStack()
        {
            var input = new[] { 9, 12, 7, 4, 17, 8, 7, 3 };

            var stack = new Stack<int>(20);
            for (var i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            Console.WriteLine($"Input: {Utils.FormatArray(input)}");
            SortStack.Sort(stack);

            var output = new int[input.Length];
            for (var i = 0; i < output.Length; i++)
            {
                output[i] = stack.Pop();
            }

            Console.WriteLine($"Output: {Utils.FormatArray(output)}");
        }
    }
}