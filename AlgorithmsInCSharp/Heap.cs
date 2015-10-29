namespace Algorithms
{
    public class Heap
    {
        public static int[] BuildMaxHeapRecursive(int[] array)
        {
            for (int i = array.Length / 2; i >= 0; i--)
            {
                MaxHeapifyRecursive(array, i);
            }

            return array;
        }
        public static void MaxHeapifyRecursive(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return;
            }

            var left = Left(index);
            var right = Right(index);
            int largest = index;
            if (left < array.Length && array[index] < array[left])
            {
                largest = left;
            }

            if (right < array.Length && array[largest] < array[right])
            {
                largest = right;
            }

            if (largest != index)
            {
                var value = array[index];
                array[index] = array[largest];
                array[largest] = value;
                MaxHeapifyRecursive(array, largest);
            }
        }

        public static int[] BuildMaxHeapIterative(int[] array)
        {
            for (int i = array.Length / 2; i >= 0; i--)
            {
                MaxHeapifyIterative(array, i);
            }

            return array;
        }

        public static void MaxHeapifyIterative(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return;
            }

            while (index < array.Length)
            {
                var left = Left(index);
                var right = Right(index);
                int largest = index;
                if (left < array.Length && array[index] < array[left])
                {
                    largest = left;
                }

                if (right < array.Length && array[largest] < array[right])
                {
                    largest = right;
                }

                if (largest != index)
                {
                    var value = array[index];
                    array[index] = array[largest];
                    array[largest] = value;
                    index = largest;
                }
                else
                {
                    break;
                }
            }
        }

        private static int Parent(int index)
        {
            // "- 1" because the array is zero based
            return (index - 1) >> 1;
        }

        private static int Left(int index)
        {
            // "1 +" because the array is zero based
            return 1 + (index << 1); 
        }
        
        private static int Right(int index)
        {
            // "1 +" because the array is zero based
            return 1 + (index << 1) + 1;
        }
    }
}