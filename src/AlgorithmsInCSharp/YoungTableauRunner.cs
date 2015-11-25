using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class YoungTableauRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Young Tabelau", RunYoungTableau);
        }

        private static void RunYoungTableau()
        {
            var input = new[] {9, 16, 3, 2, 4, 8, 5, 14, 12};
            Console.WriteLine($"Building tableau from: {Utils.FormatArray(input)}");

            var tableau = new YoungTableau(4, 4);

            foreach (var value in input)
            {
                tableau.Insert(value);
            }

            Utils.PrintYoungTableau(tableau);
            Console.WriteLine();

            Console.WriteLine("Testing if tableu contains values...");
            foreach (var value in new[] { 16, 7 , 4, 8, 90, 12 })
            {
                Console.WriteLine("    The tableau {0} the value {1}.",
                    tableau.Contains(value) ? "contains" : "does not contain", value);
            }

            Console.WriteLine("\nExtracting min values until tableau is empty...");
            while(!tableau.IsEmpty)
            {
                Console.WriteLine($"    Extracted min value: {tableau.ExtractMin()}");
            }
        }
    }
}