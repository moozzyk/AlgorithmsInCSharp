/*
Write a function that which takes as input a single positive integer n
and returns an n-bit Gray code
*/

namespace AlgorithmsInCSharp.Exercises
{
    public static class GrayCodeConverter
    {
        // note: a recursive solution to this problem exists where
        // you append 1 to the reverse of n-bit - 1 Gray code starting
        public static uint ToGray(uint number)
        {
            uint result = 0;

            for (var i = 0; i < 32; i++)
            {
                ulong offset = (uint)1 << i;
                var bit = (number > offset) && (number - offset) % (offset << 2) < (offset << 1)
                    ? 1 : 0;
                result |= (uint)bit << i;
            }

            return result;
        }
/*
Gray Gray Dec
0000  0   0
0001  1   1
0011  3   2
0010  2   3
0110  6   4
0111  7   5
0101  5   6
0100  4   7
1100 12   8
1101 13   9
1111 15   10
1110 14   11
1010 10   12
1011 11   13
1001  9   14
1000  8   15
*/
    }
}