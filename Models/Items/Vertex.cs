namespace DataStructures.Models.Items
{
    class Vertex
    {
        public int VertexNumber { get; private set; }
        public Vertex(int vertexNumber)
        {
            VertexNumber = vertexNumber;
        }

        public override string ToString()
        {
            return $"{VertexNumber}";
        }
    }
}
