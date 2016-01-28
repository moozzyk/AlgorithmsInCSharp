using System;
using AlgorithmsInCSharp.DataStructures;

namespace AlgorithmsInCSharp.Algorithms
{
    public static class Graphs
    {
        public static void BreadthFirstSearch(LinkedList<Vertex>[] graph, Vertex startVertex, Action<Vertex> vertexAction)
        {
            var vertices = new Queue<Vertex>(graph.Length);
            startVertex.Color = VertexColor.White;
            vertices.Enqueue(startVertex);

            while (!vertices.IsEmpty)
            {
                var v = vertices.Dequeue();
                v.Color = VertexColor.Black;
                vertexAction(v);

                for (var neighbour = graph[v.Id].Head; neighbour != null; neighbour = neighbour.Next)
                {
                    if (neighbour.Value.Color == VertexColor.White)
                    {
                        neighbour.Value.Color = VertexColor.Gray;
                        vertices.Enqueue(neighbour.Value);
                    }
                }
            }
        }
    }
}