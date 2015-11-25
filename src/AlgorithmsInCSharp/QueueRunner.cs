using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class QueueRunner
    {
        public static void Run()
        {
             Utils.PrintAlgorithmRun("Queue", RunQueue);
        }

        private static void RunQueue()
        {
            var queue = new Queue<int>(5);

            foreach (var item in new[] { 1, 2, 3, 4, 5})
            {
                Console.WriteLine($"Enqueuing {item}");
                queue.Enqueue(item);
            }

            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
            Console.WriteLine($"Dequeuing {queue.Dequeue()}");

            foreach (var item in new[] { 6, 7 })
            {
                Console.WriteLine($"Enqueuing {item}");
                queue.Enqueue(item);
            }

            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
            Console.WriteLine($"Dequeuing {queue.Dequeue()}");
        }
    }
}