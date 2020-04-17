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
        Dictionary<int, Dictionary<int, int>> ways;
        public static int NO_WAY = -1;

        public DijkstrasAlgorithm(Dictionary<int, Dictionary<int, int>> ways)
        {
            this.ways = ways;
        }

        public int solve(int from, int to)
        {
            int cur = from;
            int curLenWay = 0;
            int newLenWay;
            if (from == to) return 0;
            if (!ways.ContainsKey(from)) return -1;
            Dictionary<int, int> waysLen = new Dictionary<int, int>();
            foreach (var a in ways.Keys)
            {
                waysLen.Add(a, NO_WAY);
            }
            waysLen.Remove(cur);

            while (waysLen.Count > 0)
            {
                List<int> keys = new List<int>(waysLen.Keys);
                //waysLen.Keys.CopyTo(keys, 0);
                foreach (var vertexTo in keys)
                {
                    if (ways[cur].ContainsKey(vertexTo))
                    {
                        newLenWay = curLenWay + ways[cur][vertexTo];
                        if (waysLen[vertexTo] == NO_WAY || newLenWay < waysLen[vertexTo])
                        {
                            waysLen[vertexTo] = newLenWay;
                        }
                    }
                }
                int min = int.MaxValue;
                bool wasChange = false;
                foreach (var item in waysLen)
                {
                    if (item.Value != -1 && item.Value < min)
                    {
                        min = item.Value;
                        cur = item.Key;
                        wasChange = true;
                    }
                }
                if (!wasChange) return -1;
                curLenWay = waysLen[cur];
                if (cur == to) return curLenWay;
                waysLen.Remove(cur);
            }
            return -1;
        }
    }
}
