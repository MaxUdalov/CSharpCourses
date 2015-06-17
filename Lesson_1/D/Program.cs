using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Фигурное_катание___D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number of referees : ");
            string line = Console.ReadLine();
            int N = int.Parse(line);

            Console.Write("Points :");
            line = Console.ReadLine();
            string[] tokens = line.Split(' ');
            List<double> points = new List<double>();
            for (int count = 0; count < tokens.Length; count++)
            {
                points.Add(double.Parse(tokens[count]));
            }

            points.Sort();
            points.RemoveAt(0);
            points.RemoveAt(points.Count - 1);

            Console.WriteLine("Answer : {0}", Math.Round(points.Average(), 1));
            Console.ReadLine();
        }
    }
}
