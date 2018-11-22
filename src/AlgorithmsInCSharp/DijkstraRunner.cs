using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsInCSharp.Algorithms;
using AlgorithmsInCSharp.Algorithms.Misc;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class DijkstraRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Dijkstra", RunDijkstra);
        }

        private static void RunDijkstra()
        {
            var graph = new List<Edge>[]
            {
                new List<Edge> { new Edge(1, 10), new Edge(2, 5) },
                new List<Edge> { new Edge(2, 2), new Edge(3, 1) },
                new List<Edge> { new Edge(3, 9), new Edge(1, 2) },
                new List<Edge> { new Edge(4, 4) },
                new List<Edge> { new Edge(0, 7) },
            };

            Console.WriteLine("Egdes: ");
            for (int i = 0; i < graph.Length; i++)
            {
                Console.Write($"{i}: ");
                Console.WriteLine(string.Join("; ", graph[i].Select(e => $"v: {e.ToVertex} w: {e.Weight}")));
            }

            var distance = Dijkstra.ShortestPath(graph, start: 0 , target: 3);
            Console.WriteLine($"Shortest distance: {distance}");
        }
    }
}