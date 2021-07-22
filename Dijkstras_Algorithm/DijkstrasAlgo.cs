using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras_Algorithm
{
    class Path : IComparable
    {
        public int Destination;
        public int Length;

        public Path(int d, int l)
        {
            Destination = d; // значение вершины (номер)
            Length = l;  // длина дуги
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Path otherPath = obj as Path;

            if (otherPath != null)
            {
                return this.Length.CompareTo(otherPath.Length);
            }
            else
            {
                throw new ArgumentException("Object is not a Path!");
            }
        }

    }

    class DijkstrasAlgo
    {
        List<Path>[] Graph; // список смежности

        int[] a_VisitedVertexes; // массиов посещенных вершин
        HashSet<int> visitedVertexes_set;
        int[] b_LengthFromSourceToOther; // кратчайшие пути до вершин
        int[] c_VertexFromWeComeInOtherVertex; // вершины, из которых мы пришли в i-ю вершину

        int source; // откуда начинаем искать кратчайшие пути (исток)

        public DijkstrasAlgo(List<Path>[] g, int new_source)
        {
            source = new_source;

            if (source < 1)
            {
                throw new ArgumentOutOfRangeException("Source or destination is out of graph vertexes");
            }

            Graph = g;

            a_VisitedVertexes = new int[g.Length];
            a_VisitedVertexes[source] = 1;

            visitedVertexes_set = new HashSet<int>();
            visitedVertexes_set.Add(source);

            b_LengthFromSourceToOther = new int[g.Length];
            for (int i = 1; i < b_LengthFromSourceToOther.Length; ++i)
            {
                b_LengthFromSourceToOther[i] = int.MaxValue;

                if (i == source)
                {
                    b_LengthFromSourceToOther[i] = 0;
                }
            }

            c_VertexFromWeComeInOtherVertex = new int[g.Length];
        }


        public List<int> FindShortestPath(int destination, out int[] b, out int[] c)
        {
            int length_to_curr = 0;
            int curr_vertex = source;
            int new_path;

            BinaryHeapQueue<Path> length_queue = new BinaryHeapQueue<Path>();


            while (true)
            {
                length_to_curr = b_LengthFromSourceToOther[curr_vertex];

                foreach (Path p in Graph[curr_vertex])
                {

                    new_path = p.Length + length_to_curr;
                    if (new_path < b_LengthFromSourceToOther[p.Destination])
                    {
                        b_LengthFromSourceToOther[p.Destination] = new_path;
                        c_VertexFromWeComeInOtherVertex[p.Destination] = curr_vertex; //  отмечаем, откуда мы пришли в текущую
                    }

                    if (!visitedVertexes_set.Contains(p.Destination)) 
                    {
                        length_queue.Queue(p);
                    }
                }

                a_VisitedVertexes[curr_vertex] = 1; // отмечаем текущую вершину как посещенную
                visitedVertexes_set.Add(curr_vertex);

                if (length_queue.Count == 0)
                {
                    break;
                }

                curr_vertex = length_queue.Dequeue().Destination; // получаем кратчайшую дугу из текущей вершины 

            }


            List<int> res = new List<int>();
            int temp_source = destination;  
            res.Add(destination);

            while (temp_source != source)
            {
                temp_source = c_VertexFromWeComeInOtherVertex[temp_source];
                res.Add(temp_source);
            }

            b = b_LengthFromSourceToOther;
            c = c_VertexFromWeComeInOtherVertex;

            return res;

        }


        public void PrintArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

    }
}
