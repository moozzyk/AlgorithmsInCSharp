using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class PriorityQueueRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Priority Queue", RunPriorityQueue);
        }

        private static void RunPriorityQueue()
        {
            var input = new[] {5, 3, 17, 10, 84, 19, 6, 22, 9};
            Console.WriteLine($"Items: {Utils.FormatArray(input)}");

            var queue = new PriorityQueue();

            foreach (var value in input)
            {
                queue.Insert(value);
                Console.WriteLine($"Inserted: {value}, Max value {queue.Maximum}");
            }

            while (queue.HasValues)
            {
                var max = queue.ExtractMax();
                var newMax = queue.HasValues ? queue.Maximum.ToString() : "(N/A - queue is empty)";
                Console.WriteLine($"Extracted: {max}, new max value: {newMax}");
            }
        }
    }
}