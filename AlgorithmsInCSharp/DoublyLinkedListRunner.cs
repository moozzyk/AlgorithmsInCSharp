using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class DoublyLinkedListRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Doubled Linked List", RunDoublyLinkedList);
        }

        private static void RunDoublyLinkedList()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();
            Console.WriteLine("Creating a new list");
            Utils.PrintList(doublyLinkedList.Head);

            foreach (var key in new[] {10, 17, 1, 4, 9})
            {
                Console.WriteLine($"Inserting {key}");
                doublyLinkedList.Insert(key);
            }
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine("Appending 19");
            doublyLinkedList.Append(19);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            var node = doublyLinkedList.Search(17);
            Console.WriteLine($"Inserting 20 before {node.Value}");
            doublyLinkedList.InsertBefore(node, 20);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine($"Inserting 13 after {node.Value}");
            doublyLinkedList.InsertAfter(node, 13);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine("Deleting first element");
            node = doublyLinkedList.Search(9);
            doublyLinkedList.Delete(node);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine("Deleting last element");
            node = doublyLinkedList.Search(10);
            doublyLinkedList.Delete(node);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine("Deleting element in the middle");
            node = doublyLinkedList.Search(1);
            doublyLinkedList.Delete(node);
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);

            Console.WriteLine("Deleting all nodes");
            while (doublyLinkedList.Head != null)
            {
                Console.WriteLine($"Deleting {doublyLinkedList.Head.Value}");
                doublyLinkedList.Delete(doublyLinkedList.Head);
            }
            Utils.PrintList(doublyLinkedList.Head);
            Utils.PrintListReverse(doublyLinkedList.Tail);
        }
    }
}
