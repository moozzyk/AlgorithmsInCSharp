namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class InsertionSort
    {
        public static void Sort(int[] array)
        {
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
        }
    }
}