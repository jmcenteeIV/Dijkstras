using System;

public class CityProcess
{

     Random rnd = new Random();
     double fun;
     int n; //num of cities
     double[,] con_cities;//array which will hold arrays of all the nodes that will be connected
     int[][] nodes;
     int edges;
     double distance;

	public CityProcess(double[,] cities, int num)
	{
        n = num;
        con_cities = new double[num, num];
        nodes = new int[num][];
        for (int i = 0; i < num; i++)
        {
            edges = rnd.Next(1, n - 1); //how many edges this node will have
            nodes[i] = new int[edges]; //initialize array of arrays
            nodes[i] = makeEdge(n, i, edges); //Generate array of nodes for this ith node to be connected to
            for (int j = 0; j < edges; j++)
            {
                distance = calcDistance(cities[i, 0], cities[i, 1], cities[nodes[i][j], 0], cities[nodes[i][j], 1]);
                con_cities[i, nodes[i][j]] = distance;
                con_cities[nodes[i][j], i] = distance;
            }
        }
        
    }
    private int[] makeEdge(int n, int index, int numEdge)
    {
        int temp;
        bool already = false;
        int[] edgArr = new int[numEdge];
        for(int i = 0; i < edgArr.Length; i++)
        { 
            temp = rnd.Next(0, n-1);
            for(int j = 0; j < i; j++)
            {
                if(edgArr[j] == temp)
                {
                    already = true;
                    break;
                }
            }
            if (!already && temp != index) //cannot be connected to itself
                edgArr[i] = temp;
            else
                i--;
                already = false; 
        }
        return edgArr; 
    }
    private double calcDistance(double x1, double y1, double x2, double y2)
    {
        double dist = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        return dist;
    }
    public void printDistances()
    {
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if (con_cities[i,j] != fun)
                {
                    Console.Write("(" + i + "," + j + ") distance = " + con_cities[i,j] );
                    Console.WriteLine();
                }
            }
        }
    }
    public void printConnections()
    {
        Console.WriteLine("Here are the city connections");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("City " + (i + 1) + " connected to:");
            for(int j = 0; j < nodes[i].Length; j++)
            {
                Console.Write((nodes[i][j]+1) + " ");
            }
            Console.WriteLine();
        }
    }
    public double[,] getDistances()
    {
        return con_cities;
    }


}
