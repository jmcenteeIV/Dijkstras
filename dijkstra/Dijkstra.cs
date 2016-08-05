using System;


    public class Dijkstra
    {
    double fun;
        double[] dist;
        bool[] node;
        int n;
        int srcNode;


    public Dijkstra()
    {
        int num = 5;
        int src = 1;
        double[,] citieGraph = new double[,] { { double.MaxValue, 5.0, 3.0, double.MaxValue, 5.0},
                                               { 5.0, double.MaxValue, 8.0, 5.0, double.MaxValue},
                                               { 3.0, 8.0, double.MaxValue, 2.0, 4.0 },
                                               { double.MaxValue, 5.0, 2.0, double.MaxValue, double.MaxValue},
                                               { 5.0, double.MaxValue, 4.0, double.MaxValue, double.MaxValue } };
        dist = new double[num];
        node = new bool[num];
        n = num;
        srcNode = src;

        for (int i = 0; i < num; i++)
        {
            dist[i] = double.MaxValue;
            node[i] = false;
        }
        dist[src] = 0;
        for (int i = 0; i < (num - 1); i++)
        {
            int u = min(dist, node);
            node[u] = true;

            for (int j = 0; j < num; j++)
            {
                if (node[j] == false && citieGraph[u, j] != fun && dist[u] != double.MaxValue && (dist[u] + citieGraph[u, j] < dist[j]))
                {
                    dist[j] = dist[u] + citieGraph[u, j];
                }
            }
        }

    }

    public Dijkstra(double[,] citieGraph, int num, int src)
    {
        dist = new double[num];
        node = new bool[num];
        n = num;
        srcNode = src;

        for(int i = 0; i < num; i++)
        {
            dist[i] = double.MaxValue;
            node[i] = false;
        }
        dist[src] = 0;
        for (int i = 0; i < (num-1); i++)
        {
            int u = min(dist, node);
            node[u] = true;
            
            for(int j = 0; j < num-1; j++)
            {
                if(node[j] == false && citieGraph[u,j] != fun && dist[u] != double.MaxValue && (dist[u]+citieGraph[u,j] < dist[j]))
                {
                    dist[j] = dist[u] + citieGraph[u, j];
                }
            } 
        }

    }

    private int min(double[] distance, bool[] nodeSet)
    {
        double min = double.MaxValue;
        int index = -1;

        for (int i = 0; i < n; i++)
        {
            if (nodeSet[i] == false && distance[i] <= min)
            {
                min = distance[i];
                index = i;
            }
        }
        return index;

    }
    public void printMin()
    {
        for (int i = 0; i < n; i++)
        {
            if(i != srcNode)
            Console.WriteLine("The closest distances from city " + (srcNode + 1) + " to city " + (i + 1) + " is: " + dist[i]);
        }
    }

  }

