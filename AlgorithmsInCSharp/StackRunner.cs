using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class StackRunner
    {
        public static void Run()
        {
             Utils.PrintAlgorithmRun("Stack", RunStack);
        }

        private static void RunStack()
        {
            var stack = new Stack<int>(5);

            Console.WriteLine($"Stack created. Stack empty: {stack.IsEmpty}");
            Console.Write("Pushing to the stack: ");
            foreach (var item in new[] {5, 8, -3, 10})
            {
                Console.Write($"{item} ");
                stack.Push(item);
            }
            Console.WriteLine($"\nStack empty: {stack.IsEmpty}");

            Console.WriteLine("Popping from the stack: ");
            while (!stack.IsEmpty)
            {
                Console.Write($"{stack.Pop()} ");
            }
            Console.WriteLine($"\nStack empty: {stack.IsEmpty}");
        }
   }
}