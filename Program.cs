using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DijkstrasAlgorithm
{
    class Program
    {
        const string FILE_NAME = "in1.txt";

        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<int, int>> ways = new Dictionary<int, Dictionary<int, int>>();
            using (StreamReader sr = new StreamReader(FILE_NAME))
            {
                while (!sr.EndOfStream)
                {
                    string[] way = sr.ReadLine().Split(' ');
                    int from = Convert.ToInt32(way[0]);
                    int to = Convert.ToInt32(way[1]);
                    int len = Convert.ToInt32(way[2]);
                    if (!ways.ContainsKey(from))
                    {
                        ways.Add(from, new Dictionary<int, int>());
                    }
                    ways[from].Add(to, len);
                }
            }
            DijkstrasAlgorithm da = new DijkstrasAlgorithm(ways);
            Console.WriteLine(da.solve(1, 8));
            Console.ReadLine();
        }
    }
}
