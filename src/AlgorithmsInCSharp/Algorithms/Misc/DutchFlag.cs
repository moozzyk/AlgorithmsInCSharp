namespace AlgorithmsInCSharp.Algorithms.Misc
{
    public class DutchFlag
    {
        public static void Partition(int[] array, int pivotIdx)
        {
            var pivot = array[pivotIdx];
            var firstPartitionEnd = 0;
            var secondPartitionEnd = 0;
            var thirdPartitionStart = array.Length - 1;

            while (secondPartitionEnd <= thirdPartitionStart)
            {
                if (array[secondPartitionEnd] < pivot)
                {
                    swap(array, firstPartitionEnd, secondPartitionEnd);
                    secondPartitionEnd++;
                    firstPartitionEnd++;
                }
                else if (array[secondPartitionEnd] > pivot)
                {
                    swap(array, secondPartitionEnd, thirdPartitionStart);
                    thirdPartitionStart--;
                }
                else
                {
                    secondPartitionEnd++;
                }
            }
        }

        private static void swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
