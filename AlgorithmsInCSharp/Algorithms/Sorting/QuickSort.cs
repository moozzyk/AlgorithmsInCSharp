namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class QuickSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length -1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                var pivotIdx = Partition(array, left, right);
                Sort(array, left, pivotIdx - 1);
                Sort(array, pivotIdx + 1, right);
            }
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