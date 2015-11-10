using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSorting();
            //RunMaximumSubarray();
            //RunMatrixMultiplication();
            //RunHeap();
            //RunPriorityQueue();
            // RunYoungTableau();
        }

        private static void RunSorting()
        {
            var inputArray = new[] { 5, 2, 4, 6, 1, 3 };
            Sorting.InsertionSort((int[])inputArray.Clone());
            Console.WriteLine();
            Sorting.SelectionSort((int[])inputArray.Clone());
            Console.WriteLine();
            Sorting.MergeSort((int[])inputArray.Clone());
            Console.WriteLine();
            Sorting.HeapSort((int[])inputArray.Clone());
            Console.WriteLine();
            Sorting.QuickSort((int[])inputArray.Clone());
            Console.WriteLine();
            Sorting.CountingSort(new int[] { -5, 12, 3, -7, 4, 4, 9});
            Console.WriteLine();
        }

        private static void RunMaximumSubarray()
        {
            var inputArray = new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4 , 7 };

            Console.WriteLine("ON3");
            MaximumSubarray.ON3(inputArray);
            Console.WriteLine();

            Console.WriteLine("ON2_1");
            MaximumSubarray.ON2_1(inputArray);
            Console.WriteLine();

            Console.WriteLine("ON2_2");
            MaximumSubarray.ON2_2(inputArray);
            Console.WriteLine();

            Console.WriteLine("NlogN");
            MaximumSubarray.ONlogN(inputArray);
            Console.WriteLine();

            Console.WriteLine("N");
            MaximumSubarray.ON(inputArray);
            Console.WriteLine();

            Console.WriteLine();
        }

        private static void RunMatrixMultiplication()
        {
            var A = new[,]
            {
                {2, 3, 4},
                {0, 7, 4},
                {4, 3, 6},
                {2, 2, 9}
            };

            var B = new[,]
            {
                {3, 9},
                {5, 2},
                {8, 1}
            };

            MatrixMultiplication.ON3(A, B);

            Console.WriteLine();

            //var C = new[,]
            //{
            //    {1, 3, 4, 9},
            //    {7, 5, 6, 1},
            //    {2, 6, 0, 4},
            //    {7, 2, 2, 3},
            //};

            //var D = new[,]
            //{
            //    {6, 8, 7, -2},
            //    {4, 2, 0, 2},
            //    {-1, 4, 4, 4},
            //    {2, 6, 3, -4}
            //};

            var C = new[,]
            {
                {1, 3, 4, 9, 1, 4, -5, 6},
                {7, 5, 6, 1, -9, 0, 2, 3},
                {2, 6, 0, 4, -4, -5, 1, 7},
                {7, 2, 2, 3, 4, 2, 3, 3},
                {5, 1, 5, 3, 3, -3, -4, 1},
                {3, 2, 2, 1, 9, 3, -3, -3},
                {9, 3, 1, 1, 7, 4, 5, 5},
                {8, 8, 8, 4, 1, 2, 5, 9}
            };

            var D = new[,]
            {
                {6, 8, 7, -2, 1, 7, 2, 7},
                {4, 2, 0, 2, 3, 3, 1, 1},
                {-1, 4, 4, 4, 3, -4, -3, 5},
                {2, 6, 3, -4, 1, 5, 0, 4},
                {9, 2, 1, 1, 1, 7, 2, 7},
                {1, 3, 3, -4, -9, 0, 2, 3},
                {8, 3, 2, 3, 9, 4, 5, 9},
                {6, 2, -5, 2, 3, 1, 1, 8}
            };

            MatrixMultiplication.ON3(C, D);
            Console.WriteLine();
            MatrixMultiplication.RecursiveON3(C, D);
            Console.WriteLine();
            MatrixMultiplication.Recursive(C, D);
        }

        private static void RunHeap()
        {
            var input = new[] {5, 3, 17, 10, 84, 19, 6, 22, 9};
            Utils.PrintArray(input);
            Console.WriteLine("\nBuilding max heap recursively");
            Utils.PrintArray(Heap.BuildMaxHeapRecursive((int[])input.Clone()));
            Console.WriteLine("\nBuilding max heap iteratively");
            Utils.PrintArray(Heap.BuildMaxHeapIterative((int[])input.Clone()));
            Console.WriteLine();
        }

        private static void RunPriorityQueue()
        {
            var input = new[] {5, 3, 17, 10, 84, 19, 6, 22, 9};
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

        private static void RunYoungTableau()
        {
            var input = new[] {9, 16, 3, 2, 4, 8, 5, 14, 12};
            var tableau = new YoungTableau(4, 4);

            foreach (var value in input)
            {
                tableau.Insert(value);
            }

            Utils.PrintYoungTableau(tableau);

            foreach (var value in new[] { 16, 7 , 4, 8, 90, 12 })
            {
                Console.WriteLine("The tableau {0} the value {1}.", 
                    tableau.Contains(value) ? "contains" : "does not contain", value);
            }

            while(!tableau.IsEmpty)
            {
                Console.WriteLine($"Extracted min value: {tableau.ExtractMin()}");
            }
        }
    }
}
