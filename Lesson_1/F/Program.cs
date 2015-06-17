using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сортировка_времени___F
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N : ");
            string line = Console.ReadLine();
            string[] tokens = new string[3];
            int N = int.Parse(line);
            TimeSpan time = new TimeSpan();
            List<TimeSpan> Times = new List<TimeSpan>();
            Console.Write("Time : ");
            for (int count = 0; count < N; count++)
            {
                line = Console.ReadLine();
                tokens = line.Split(' ');
                time = time.Add(new TimeSpan(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2])));
                Times.Add(time);
                time = new TimeSpan(0, 0, 0);
            }

            Times.Sort();

            Console.Write("Answer : ");
            for (int count = 0; count < N; count++)
                Console.WriteLine("{0}\n          ", Times[count]);
            Console.ReadLine();
        }
    }
}
