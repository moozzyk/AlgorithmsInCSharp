using System;

namespace Algorithms
{
    class Sorting
    {
        public static void InsertionSort(int[] array)
        {
            Console.WriteLine("Insertion sort");
            Utils.PrintArray(array);
            Console.Write(" => ");

            for(var i = 1; i < array.Length; i++)
            {
                var key = array[i];

                var j = i - 1;
                for (; j >= 0 && array[j] > key; j--)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = key;
            }

            Utils.PrintArray(array);
            Console.WriteLine();
        }

        public static void SelectionSort(int[] array)
        {
            Console.WriteLine("Selection sort");
            Utils.PrintArray(array);
            Console.Write(" => ");

            for(int i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                for(int j = i; j < array.Length; j++)
                {
                    if(array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }

            Utils.PrintArray(array);
            Console.WriteLine();
        }

        public static void MergeSort(int[] array)
        {
            Console.WriteLine("Selection sort");
            Utils.PrintArray(array);
            Console.Write(" => ");

            MergeSort(array, 0, array.Length - 1);

            Utils.PrintArray(array);
            Console.WriteLine();
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if(left == right)
            {
                return;
            }

            int pivot = left + (right - left) / 2;

            MergeSort(array, left, pivot);
            MergeSort(array, pivot + 1, right);
            Merge(array, left, pivot, right);
        }

        private static void Merge(int[] array, int left, int pivot, int right)
        {
            var tmpArray = new int[right - left + 1];
            var leftIndex = left;
            var rightIndex = pivot + 1;

            for(int i = 0; i < right - left + 1; i++)
            {
                if(rightIndex > right)
                {
                    tmpArray[i] = array[leftIndex];
                    leftIndex++;
                }
                else if (leftIndex > pivot)
                {
                    tmpArray[i] = array[rightIndex];
                    rightIndex++;
                }
                else if (array[leftIndex] < array[rightIndex])
                {
                    tmpArray[i] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    tmpArray[i] = array[rightIndex];
                    rightIndex++;
                }
            }

            for (int i = 0; i < tmpArray.Length; i++)
            {
                array[left + i] = tmpArray[i];
            }
        }

        public static void HeapSort(int[] array)
        {
            Console.WriteLine("Heap sort");
            Utils.PrintArray(array);
            Console.Write(" => ");

            Heap.BuildMaxHeapRecursive(array);
            for (var i = array.Length - 1; i > 0; i--)
            {
                var tmp = array[0];
                array[0] = array[i];
                array[i] = tmp;
                Heap.MaxHeapifyIterative(array, 0, arraySize: i);
            }

            Utils.PrintArray(array);
            Console.WriteLine();
        }
    }
}
