using System;
using System.Linq;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class HashtableRunner
    {
        public static void Run()
        {
            int size = 3;
            var keys = new[] { "123", "abc", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "1234567890", "123"};
            var nonExistingKey = "~!@#$%^";

             Utils.PrintAlgorithmRun(
                 "Hashtable - chaining collision resolution", () => RunHashtable_Chaining.Run(size, keys, nonExistingKey));

             Utils.PrintAlgorithmRun(
                 "Hashtable - open addressing resolution", () => RunHashtable_OpenAddressing.Run(size, keys, nonExistingKey));
        }

        private static class RunHashtable_Chaining
        {
            public static void Run(int size, string[] keys, string nonExistingKey)
            {
                var hashtable = new Hashtable_Chaining<string>(size, DivisionHashFunction);

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

        private static class RunHashtable_OpenAddressing
        {
            public static void Run(int size, string[] keys, string nonExistingKey)
            {
                var hashtable = new Hashtable_OpenAddressing<string>(size, DivisionHashFunction);

                foreach (var key in keys)
                {
                    Console.WriteLine($"Adding: {key}, hash value: {DivisionHashFunction(key)}");
                    try
                    {
                        hashtable.Add(key);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Failed to add {key}. Exception: {ex.Message}");
                    }
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

                foreach (var key in keys.Concat(new[] { nonExistingKey }))
                {
                    Console.WriteLine($"Retrieving key: {key}. Result: {hashtable.Get(key) == key}");
                }
                Console.WriteLine();
            }

            private static void PrintHashtable<T>(Hashtable_OpenAddressing<T> hashtable)
            {
                Console.WriteLine("Hashtable contents: ");

                Console.WriteLine(
                    string.Join(", ",
                        hashtable.Hashtable.Select(
                            k => string.Format("{0}{1}", k, Equals(k, default(T)) ? "(nil)" : string.Empty))));

                Console.WriteLine();
            }
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
    }
}