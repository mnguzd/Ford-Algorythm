using Diskretka_Lab3.Graph;
using System.Collections.Generic;

namespace Diskretka_Lab3
{
    class Program
    {
        static void Main()
        {
            List<Edge> Graph = new List<Edge> 
            {
                new Edge(1,3,1),new Edge(2,4,2),new Edge(0,2,3),
                new Edge(4,5,4),new Edge(3,5,5),new Edge(4,6,6),
                new Edge(0,1,5),new Edge(0,3,5),new Edge(0,5,8),
                new Edge(0,4,6),new Edge(1,4,4),new Edge(3,4,3),
                new Edge(5,6,5)
            };
            Bellman_Kalaba.MinWay(Graph, 1, 6);
        }
    }
}
