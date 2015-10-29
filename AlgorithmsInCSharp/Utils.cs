using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Utils
    {
        public static void PrintArray<T>(IEnumerable<T> array)
        {
            Console.Write("[{0}]", string.Join(", ", array.Select(i => i.ToString())));
        }
    }
}
