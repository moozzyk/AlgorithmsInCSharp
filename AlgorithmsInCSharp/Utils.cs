using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class Utils
    {
        public static void PrintArray<T>(IEnumerable<T> array)
        {
            Console.Write("[{0}]", string.Join(", ", array.Select(i => i.ToString())));
        }

        public static void PrintYoungTableau(YoungTableau tableau)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < tableau.Rows; row++)
            {
                sb.Length = 0;
                for (var col = 0; col < tableau.Columns; col++)
                {
                    sb.Append(string.Format("{0, 5}, ", 
                        tableau.Values[col, row] == int.MaxValue ? "  -  " : tableau.Values[col, row].ToString()));
                }
                sb.Length = sb.Length - 2;
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
