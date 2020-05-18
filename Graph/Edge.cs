namespace Diskretka_Lab3.Graph
{
    public class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Value { get; set; }
        public Edge(int first, int second, int value)
        {
            First = first;
            Second = second;
            Value = value;
        }
    }
}
