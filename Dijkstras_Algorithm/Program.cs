using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Path>[] g = new List<Path>[9];
  
            for (int i = 1; i < g.Length; ++i)
            {
                g[i] = new List<Path>();
            }

            g[1].Add(new Path(4, 5));
            g[1].Add(new Path(3, 2));

            g[2].Add(new Path(1, 1));

            g[3].Add(new Path(8, 4));
            g[3].Add(new Path(6, 2));

            g[4].Add(new Path(3, 8));
            g[4].Add(new Path(5, 3));

            g[5].Add(new Path(2, 9));

            g[6].Add(new Path(2, 4));
            g[6].Add(new Path(7, 7));

            g[7].Add(new Path(5, 6));

            g[8].Add(new Path(7, 6));


            int source = 6;
            int destination = 1;

            DijkstrasAlgo da = new DijkstrasAlgo(g, source);

            int[] b, c;

            Console.WriteLine();
            for (int i = 1; i <= 8; ++i)
            {
                if (i == source)
                {
                    continue;
                }

                destination = i;
                List<int> list_shortest_path = da.FindShortestPath(destination, out b, out c);

                Console.Write($"Shortest path from {source} to {destination}: ");
                string t = "";
                for (int j = list_shortest_path.Count - 1; j >= 0; --j)
                {
                    t += $"{list_shortest_path[j]} ";
                }
                Console.Write("{0, -13} Path length: {1, 3}\n", t, b[i]);
            }

            Console.WriteLine();

        }

    }
}
