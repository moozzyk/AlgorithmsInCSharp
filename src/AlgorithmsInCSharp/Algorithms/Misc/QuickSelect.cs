using System;

namespace AlgorithmsInCSharp.Algorithms.Misc
{
    public static class QuickSelect
    {
        public static int Select(int[] array, int n)
        {
            if (n < 0 || n >= array.Length)
            {
                throw new ArgumentException("n must must be with 0..array.Length - 1 range.", "n");
            }

            return Select(array, 0, array.Length - 1, n);
        }

        private static int Select(int[] array, int left, int right, int n)
        {
            var pivot = Partition(array, left, right);
            if (pivot == n)
            {
                return array[pivot];
            }

            if (pivot > n)
            {
                return Select(array, left, pivot - 1, n);
            }

            return Select(array, pivot + 1, right, n);
        }

        private static int Partition(int[] array, int left, int right)
        {
            var pivotValue = array[right];

            var partitionIdx = left - 1;
            for (var i = left; i < right; i++)
            {
                if (array[i] < pivotValue)
                {
                    partitionIdx++;
                    var tmp = array[partitionIdx];
                    array[partitionIdx] = array[i];
                    array[i] = tmp;
                }
            }

            partitionIdx++;
            array[right] = array[partitionIdx];
            array[partitionIdx] = pivotValue;
            return partitionIdx;
        }
    }
}