using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DijkstrasAlgorithm
{
    class Program
    {
        const string FILE_NAME = "in4.txt";
        static Regex regex = new Regex(@"^[A-Za-z]*[0-9]*.txt$");

        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<int, int>> ways = new Dictionary<int, Dictionary<int, int>>();

            DijkstrasAlgorithm da = new DijkstrasAlgorithm(ways);
            Console.WriteLine("Возможные файлы: ");
            int some = 0;
            DirectoryInfo df = new DirectoryInfo(Directory.GetCurrentDirectory());
            var fi = df.GetFiles();
            var filesNamesPair = fi.Where(x => regex.IsMatch(x.Name)).Select(x => new KeyValuePair<int, string>(++some, x.Name)).ToArray();
            foreach (var item in filesNamesPair)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.Write("Выберете файл: ");
            int nf = Convert.ToInt32(Console.ReadLine());
            using (StreamReader sr = new StreamReader(filesNamesPair.Where(x => x.Key == nf).First().Value))
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
                    if (!ways.ContainsKey(to))
                    {
                        ways.Add(to, new Dictionary<int, int>());
                    }
                    ways[from].Add(to, len);
                }
            }
            Console.Write("Введите от какой вершины вести поиск: ");
            int from1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите до какой вершины находить минимальный путь: ");
            int to1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(da.solve(from1, to1));
            Console.WriteLine("Для выхода нажмите ВВОД");
            Console.ReadLine();
        }
    }
}
