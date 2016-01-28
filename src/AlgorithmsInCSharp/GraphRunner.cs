using System;
using System.Linq;
using AlgorithmsInCSharp.Algorithms;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp
{
    internal static class GraphRunner
    {
        public static void Run()
        {
            Utils.PrintAlgorithmRun("Graph - Breadth First Search", RunBreadthFirstSearch);
            Utils.PrintAlgorithmRun("Graph - Depth First Search", RunDepthFirstSearch);
        }

        private static void RunBreadthFirstSearch()
        {
            var vertices = Enumerable.Range(0, 8).Select(i => new Vertex(i)).ToArray();

            var graph = CreateGraph(vertices,
                /* 0 -> */ new[] {1, 7},
                /* 1 -> */ new[] {6, 0},
                /* 2 -> */ new[] {3, 5, 6},
                /* 3 -> */ new[] {4, 5, 2},
                /* 4 -> */ new[] {5, 3},
                /* 5 -> */ new[] {4, 6, 2, 3},
                /* 6 -> */ new[] {5, 1, 2},
                /* 7 -> */ new[] {0});

            Console.WriteLine("Graph:");
            for(var i = 0; i < vertices.Length; i++)
            {
                Console.Write($"{i}: ");

                for (var node = graph[i].Head; node != null; node = node.Next)
                {
                    Console.Write($"{node.Value.Id} -> ");
                }

                Console.WriteLine("null");
            }

            Console.Write("Visited nodes: ");
            Graphs.BreadthFirstSearch(graph, vertices[1], v => Console.Write($"{v.Id} "));
            Console.WriteLine();
        }

        private static void RunDepthFirstSearch()
        {
            var vertices = Enumerable.Range(0, 6).Select(i => new Vertex(i)).ToArray();

            var graph = CreateGraph(vertices,
                /* 0 -> */ new[] {1, 3},
                /* 1 -> */ new[] {4},
                /* 2 -> */ new[] {5, 4},
                /* 3 -> */ new[] {1},
                /* 4 -> */ new int[0],
                /* 5 -> */ new[] {5});

            Console.WriteLine("Graph:");
            for(var i = 0; i < vertices.Length; i++)
            {
                Console.Write($"{i}: ");

                for (var node = graph[i].Head; node != null; node = node.Next)
                {
                    Console.Write($"{node.Value.Id} -> ");
                }

                Console.WriteLine("null");
            }

            Console.Write("Visited nodes: ");
            Graphs.DepthFirstSearch(vertices, graph, v => Console.Write($"{v.Id} "));
            Console.WriteLine();
        }

        private static LinkedList<Vertex>[] CreateGraph(Vertex[] vertices, params int[][] adjecentVertices)
        {
            var graph = vertices.Select(v => new LinkedList<Vertex>()).ToArray();

            for (var i = 0; i < adjecentVertices.Length; i++)
            {
                for (var j = adjecentVertices[i].Length - 1; j >= 0; --j)
                {
                    graph[i].Insert(vertices[adjecentVertices[i][j]]);
                }
            }

            return graph;
        }
    }
}