using System;
using System.Linq;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class HashtableRunner
    {
        public static void Run()
        {
             Utils.PrintAlgorithmRun("Hashtable - chaining collision resolution", RunHashtableChaining);
        }

        private static void RunHashtableChaining()
        {
            var hashtable = new Hashtable_Chaining<string>(3, DivisionHashFunction);
            var keys = new[] { "123", "abc", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "1234567890"};
            var nonExistingKey = "~!@#$%^";

            foreach (var key in keys)
            {
                Console.WriteLine($"Adding: {key}, hash value: {DivisionHashFunction(key)}");
                hashtable.Add(key);
            }
            Console.WriteLine();

            PrintHashtable(hashtable);

            foreach (var key in keys.Concat(new[] { nonExistingKey }))
            {
                Console.WriteLine($"Retrieving key: {key}. Result: {hashtable.Get(key) == key}");
            }
            Console.WriteLine();

            Console.WriteLine($"Deleting {keys[0]}. Result {hashtable.Delete(keys[0])}");
            Console.WriteLine($"Deleting {keys[2]}. Result {hashtable.Delete(keys[2])}");
            Console.WriteLine($"Deleting {nonExistingKey}. Result {hashtable.Delete(nonExistingKey)}");
            Console.WriteLine();

            PrintHashtable(hashtable);
        }

        private static int DivisionHashFunction(string key)
        {
            var hash = 0;
            for (var i = 0; i < key.Length; i++)
            {
                hash += key[i] * 128 * i;
            }

            return hash;
        }

        private static void PrintHashtable<T>(Hashtable_Chaining<T> hashtable)
        {
            Console.WriteLine("Hashtable contents: ");
            foreach (var list in hashtable.Hashtable)
            {
                Utils.PrintList<T>(list.Head);
            }
            Console.WriteLine();
        }
    }
}