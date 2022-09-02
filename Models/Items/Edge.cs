namespace DataStructures.Models.Items
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }
        public Edge(Vertex from, Vertex to)
        {
            From = from;
            To = to;
        }
        public Edge(Vertex from, Vertex to, int weight) : this(from, to)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Weight}";
        }
    }
}
