namespace AlgorithmsInCSharp.Algorithms.Sorting
{
    public static class SelectionSort
    {
        public static void Sort(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                for(var j = i; j < array.Length; j++)
                {
                    if(array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                var tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }
    }
}