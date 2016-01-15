using System;

namespace AlgorithmsInCSharp.Algorithms.Misc
{
    public class ArrayRotation
    {
        public static void Rotate(int[] array, int positions)
        {
            positions = positions % array.Length;

            for (int start = 0, itemsRotated = 0; itemsRotated < array.Length; start++)
            {
                var pos = start;
                var item = array[pos];
                do
                {
                    pos = (pos + positions) % array.Length;
                    var tmp = array[pos];
                    array[pos] = item;
                    item = tmp;
                    itemsRotated++;
                }
                while (pos != start);
                itemsRotated++;
            }
        }

        public static void Rotate_Reverse(int[] array, int positions)
        {
            Array.Reverse(array);
            Array.Reverse(array, 0, positions);
            Array.Reverse(array, positions, array.Length - positions);
        }
    }
}