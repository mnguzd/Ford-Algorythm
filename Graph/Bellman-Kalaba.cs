using System;
using System.Collections.Generic;

namespace Diskretka_Lab3.Graph
{
    public class Bellman_Kalaba
    {
        private const double positiveInfinity = double.PositiveInfinity;
        public static void MinWay(List<Edge> Graph,int StartVertex, int to)
        {
            int num = 0;
            for (int i = 0; i < Graph.Count; i++)
                if (Graph[i].Second > num || Graph[i].First > num)
                    num = Math.Max(Graph[i].First, Graph[i].Second);
            double[] Distance = new double[num + 1];
            int[] Prev = new int[num + 1];
            for (int i = 0; i < Distance.Length; i++)
            {
                Distance[i] = positiveInfinity;
                Prev[i] = -1;
            }
            Distance[StartVertex] = 0;
            for (int i = 0; i < Distance.Length; i++)
                for (int j = 0; j < Graph.Count; j++)
                    if (Distance[Graph[j].Second] > Distance[Graph[j].First] + Graph[j].Value)
                    {
                        Distance[Graph[j].Second] = Distance[Graph[j].First] + Graph[j].Value;
                        Prev[Graph[j].Second] = Graph[j].First;
                    }
            Console.WriteLine("Алгоритм Беллмана-Калаба для поиска минимального пути от вершины " + StartVertex + " до " + to+" :");
            for(int i = 0; i < Distance.Length; i++)
                Console.WriteLine("От вершины " + StartVertex + " до " + i + " = " + Distance[i]);
            if (Distance[to] == positiveInfinity)
                Console.WriteLine("\nНет пути от " + StartVertex + " до " + to);
            else
            {
                Console.WriteLine("\nПуть от вершины " + StartVertex + " до " + to + " :");
                List<int> path = new List<int>();
                for (int cur = to; cur != -1; cur = Prev[cur])
                    path.Add(cur);
                path.Reverse();
                for (int i = 0; i < path.Count; i++)
                {
                    if (i != path.Count - 1)
                        Console.Write(path[i] + "->");
                    else
                        Console.WriteLine(path[i] + " , расстояние = " + Distance[to]);
                }
            }
        }
    }
}
