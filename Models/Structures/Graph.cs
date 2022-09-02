using DataStructures.Models.Items;
using System.Collections.Generic;

namespace DataStructures.Models.Structures
{
    class Graph
    {
        public List<Vertex> Vertexes { get; private set; }
        public List<Edge> Edges { get; private set; }
        public int Count => Vertexes.Count;

        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
        }
        public Graph(List<Vertex> vertexes, List<Edge> edges)
        {
            Vertexes = vertexes;
            Edges = edges;
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
        public void AddEdge(Vertex from, Vertex to)
        {
            Edges.Add(new Edge(from, to));
        }

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddVertex(int vertexNumber)
        {
            Vertexes.Add(new Vertex(vertexNumber));
        }

        public int[,] GetMatrix()
        {
            if (Count <= 0)
                return default;

            var matrix = new int[Count, Count];
            foreach (var edge in Edges)
            {
                var column = edge.From.VertexNumber - 1;
                var row = edge.To.VertexNumber - 1;

                matrix[column, row] = edge.Weight;
            }

            return matrix;
        }

        public bool Wave(Vertex startVertex, Vertex endVertex)
        {
            if (Count <= 0 || startVertex == null || endVertex == null)
                return false;

            var result = new List<Vertex>();
            result.Add(startVertex);
            Vertex currentVertex;

            for (int i = 0; i < result.Count; i++)
            {
                currentVertex = result[i];
                foreach (var vertex in GetVertexLinks(currentVertex))
                {
                    if (!result.Contains(vertex))
                        result.Add(vertex);
                }
            }
            return result.Contains(endVertex);
        }

        public IEnumerable<Vertex> GetVertexLinks(Vertex vertex)
        {
            if (Edges.Count <= 0)
                yield break;
            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    yield return edge.To;
                }
            }
        }
    }
}
