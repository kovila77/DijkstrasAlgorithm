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
            Dictionary<int, int> waysLen = new Dictionary<int, int>();
            foreach (var a in ways.Keys)
            {
                waysLen.Add(a, NO_WAY);
            }
            waysLen.Remove(cur);

            while (waysLen.Count > 0)
            {
                foreach (var vertexTo in waysLen)
                {
                    if (ways[cur].ContainsKey(vertexTo.Key))
                    {
                        newLenWay = curLenWay + ways[cur][vertexTo.Key];
                        if (vertexTo.Value == NO_WAY || newLenWay < vertexTo.Value)
                        {
                            waysLen[vertexTo.Key] = newLenWay;
                        }
                    }
                }
                cur = waysLen.Keys.Min();
                curLenWay = waysLen[cur];
                if (cur == to) return curLenWay;
                waysLen.Remove(cur);
            }
            return -1;
        }
    }
}
