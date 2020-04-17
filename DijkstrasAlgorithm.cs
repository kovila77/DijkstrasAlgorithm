using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstrasAlgorithm
{

    class Way
    {
        public int from;
        public int to;
        public int len;
        public Way(int from, int to, int len)
        {
            this.from = from;
            this.to = to;
            this.len = len;
        }
    }

    class DijkstrasAlgorithm
    {
        Dictionary<int, KeyValuePair<int, int>> ways;
        public static int NO_WAY = -1;

        public DijkstrasAlgorithm(Dictionary<int, KeyValuePair<int, int>> ways)
        {
            this.ways = ways;
        }

        public int solve(int from, int to)
        {
            int cur = from;
            Dictionary<int, int> wayLen = new Dictionary<int, int>();
            foreach(var a in ways.Keys)
            {
                wayLen.Add(a, NO_WAY);
            }
            wayLen.Remove(cur);

            while (true)
            {
                foreach (var ver in wayLen.Keys)
                {
                    if (ways[ )
                }
            }



        }
    }
}
