namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if(left == right)
            {
                return;
            }

            var pivot = left + (right - left) / 2;

            Sort(array, left, pivot);
            Sort(array, pivot + 1, right);
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
    }
}