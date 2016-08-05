using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dijkstra_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int arrycount = 0;
            int countmin = 0;
            int countmax = 0;
            int src;
            string line;
            string sstring1;
            string sstring2;
            double[,] cities;

          //var fileStream = new FileStream("Sweden.txt", FileMode.Open, FileAccess.Read); /*  Can not run due to memory constraints */
          //var fileStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
          var fileStream = new FileStream("Djibouti.txt", FileMode.Open, FileAccess.Read);
          //var fileStream = new FileStream("Qatar.txt", FileMode.Open, FileAccess.Read);
          // var fileStream = new FileStream("Zimbabwe.txt", FileMode.Open, FileAccess.Read);
          //var fileStream = new FileStream("Western Sahara.txt", FileMode.Open, FileAccess.Read);
           using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                line = streamReader.ReadLine();
                n = Convert.ToInt32(line);
                cities = new double[n, 2];
                Console.WriteLine(n);
                while((line = streamReader.ReadLine()) != null)
                {
                    while(line[countmin] != ' ')
                    {
                        countmin++;
                    }
                    countmin++;
                    countmax = countmin;
                    while(line[countmax] != ' ')
                    {
                        countmax++;
                    }
                    sstring1 = line.Substring(countmin, ((countmax - 1)- countmin));  //countmin is beginning of x position double, count max at end.

                    countmax++;
                    countmin = line.Length - 1;
                    sstring2 = line.Substring(countmax, (countmin - countmax));  //reversed, countmax is at beginning countmin at end of it
                    cities[arrycount, 0] = Convert.ToDouble(sstring1); //x
                    cities[arrycount, 1] = Convert.ToDouble(sstring2); //y

                    countmax = 0;
                    countmin = 0;
                    arrycount++;
                }
                
            } 
            CityProcess city = new CityProcess(cities, n);
           // city.printConnections();
            
           for (int i = 0; i < n; i++)
            {
                Dijkstra shortest = new Dijkstra(city.getDistances(), n, i);
                shortest.printMin();
                Console.WriteLine();
            }



            //city.printDistances();

            /*for(int i = 0; i < n ; i++)
            {
                Console.WriteLine("The cities " + i + " with x-position " + cities[i, 0] + " and y-position " + cities[i, 1]);
            }*/



            //Dijkstra test = new Dijkstra();
            //test.printMin();
            Console.WriteLine();
        }

    }
}
