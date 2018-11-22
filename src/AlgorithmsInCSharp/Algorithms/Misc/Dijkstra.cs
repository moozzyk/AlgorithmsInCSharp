using System;
using System.Collections.Generic;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Algorithms.Misc
{
    public class Edge
    {
        public int Weight { get; }
        public int ToVertex { get; }

        public Edge(int toVertex, int weight)
        {
            ToVertex = toVertex;
            Weight = weight;
        }
    }
    public static class Dijkstra
    {
        public static int ShortestPath(IList<Edge>[] graph, int start, int target)
        {
            var dist = new List<int>(graph.Length + 1);
            for (var i = 0; i < graph.Length + 1; i++)
            {
                dist.Add(int.MaxValue);
            }

            var q = new MinHeap<QueueItem>();
            dist[start] = 0;
            q.Insert(new QueueItem(weight: 0, vertex: start));
            while (!q.IsEmpty)
            {
                var current = q.FindMin();
                q.DeleteMin();

                foreach (var e in graph[current.Vertex])
                {
                    int newDistance = e.Weight + current.Weight;
                    if (dist[e.ToVertex] > newDistance)
                    {
                        dist[e.ToVertex] = newDistance;
                        q.Insert(new QueueItem(weight: newDistance, vertex: e.ToVertex));
                    }
                }
            }
            return dist[target];
        }

        private class QueueItem: IComparable<QueueItem>
        {
            public int Weight { get; }
            public int Vertex { get; }

            public QueueItem(int weight, int vertex)
            {
                Weight = weight;
                Vertex = vertex;
            }
            public int CompareTo(QueueItem other) => Weight.CompareTo(other.Weight);
        }
    }
}