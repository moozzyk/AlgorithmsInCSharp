using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class HeapSort
    {
        public static void Sort(int[] array)
        {
            Heap.BuildMaxHeapRecursive(array);
            for (var i = array.Length - 1; i > 0; i--)
            {
                var tmp = array[0];
                array[0] = array[i];
                array[i] = tmp;
                Heap.MaxHeapifyIterative(array, 0, arraySize: i);
            }
        }
    }
}