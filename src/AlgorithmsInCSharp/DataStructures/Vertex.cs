namespace AlgorithmsInCSharp.DataStructures
{
    public enum VertexColor { White, Gray, Black }

    public class Vertex
    {
        public int Id { get; }
        public VertexColor Color { get; set; }

        public Vertex(int id)
        {
            Id = id;
        }
    }
}
