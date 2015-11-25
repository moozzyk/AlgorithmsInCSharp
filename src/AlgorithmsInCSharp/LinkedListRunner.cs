using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class LinkedListRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Linked List", RunLinkedList);
        }

        private static void RunLinkedList()
        {
            var linkedList = new LinkedList<int>();
            Console.WriteLine("Creating a new list");
            Utils.PrintList(linkedList.Head);

            foreach (var key in new[] {10, 17, 1, 4, 9})
            {
                Console.WriteLine($"Inserting {key}");
                linkedList.Insert(key);
            }
            Utils.PrintList(linkedList.Head);

            Console.WriteLine("Deleting first element");
            var node = linkedList.Search(9);
            linkedList.Delete(node);
            Utils.PrintList(linkedList.Head);

            Console.WriteLine("Deleting last element");
            node = linkedList.Search(10);
            linkedList.Delete(node);
            Utils.PrintList(linkedList.Head);

            Console.WriteLine("Deleting element in the middle");
            node = linkedList.Search(1);
            linkedList.Delete(node);
            Utils.PrintList(linkedList.Head);

            Console.WriteLine("Deleting all nodes");
            while (linkedList.Head != null)
            {
                linkedList.Delete(linkedList.Head);
            }
            Utils.PrintList(linkedList.Head);
        }
    }
}
