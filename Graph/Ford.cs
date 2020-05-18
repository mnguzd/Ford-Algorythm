using System;
using System.Collections.Generic;

namespace Diskretka_Lab3.Graph
{
    public static class Ford
    {
        private const double positiveInfinity = double.PositiveInfinity;

        public static void MinWay(List<Edge> Graph, int StartVertex, int to)
        {
            int NumberOfVertex = 0;

            for (int i = 0; i < Graph.Count; i++) //Getting number of vertexes
                if (Graph[i].Second > NumberOfVertex || Graph[i].First > NumberOfVertex)
                    NumberOfVertex = Math.Max(Graph[i].First, Graph[i].Second);

            double[] Distance = new double[NumberOfVertex + 1];
            int[] Prev = new int[NumberOfVertex + 1];

            for (int i = 0; i < Distance.Length; i++)
            {
                Distance[i] = positiveInfinity;
                Prev[i] = -1;
            }

            Distance[StartVertex] = 0;

            for (int i = 0; i < Distance.Length; i++)
            {
                for (int j = 0; j < Graph.Count; j++)
                {
                        if (Distance[Graph[j].Second] > Distance[Graph[j].First] + Graph[j].Value)
                        {
                            Distance[Graph[j].Second] = Distance[Graph[j].First] + Graph[j].Value;
                            Prev[Graph[j].Second] = Graph[j].First;
                        }
                }
            }
            Console.WriteLine("Алгоритм Форда для поиска минимального пути от вершины " + StartVertex + " до "+to+" :");
            if (Distance[to] == positiveInfinity)
                Console.WriteLine("\nНет пути от " + StartVertex + " до " + to+"\n");
            else
            {
                Console.WriteLine("\nПуть от вершины " + StartVertex + " до " + to + " :");
                List<int> path = new List<int>();
                for (int cur = to; cur != -1; cur = Prev[cur])
                {
                    path.Add(cur);
                }
                path.Reverse();
                for(int i = 0; i < path.Count; i++)
                {
                    if (i != path.Count - 1)
                        Console.Write(path[i] + "->");
                    else
                        Console.WriteLine(path[i]+" , расстояние = "+Distance[to]+"\n");
                }
            }
        }
    }
}
