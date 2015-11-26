using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class BucketSort
    {
        public static void Sort(double[] array)
        {
            var buckets = new DoublyLinkedList<double>[10];
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new DoublyLinkedList<double>();
            }

            foreach (var v in array)
            {
                if (v < 0 || v >= 1)
                {
                    throw new InvalidOperationException($"{v} is not in [0..1) range.");
                }
                buckets[(int)(v * 10)].Insert(v);
            }

            foreach (var bucket in buckets)
            {
                InsertionSort(bucket);
            }

            var index = 0;
            foreach (var bucket in buckets)
            {
                for (var node = bucket.Head; node != null; node = node.Next)
                {
                    array[index++] = node.Value;
                }
            }
        }

        private static void InsertionSort(DoublyLinkedList<double> bucket)
        {
            if (bucket.Head == null)
            {
                return;
            }

            var currentNode = bucket.Head.Next;
            while (currentNode != null)
            {
                var node = currentNode.Previous;
                while (node != null && node.Value > currentNode.Value)
                {
                    node = node.Previous;
                }

                bucket.Delete(currentNode);
                if (node != null)
                {
                    bucket.InsertAfter(node, currentNode.Value);
                }
                else
                {
                    bucket.Insert(currentNode.Value);
                }

                currentNode = currentNode.Next;
            }
        }
    }
}