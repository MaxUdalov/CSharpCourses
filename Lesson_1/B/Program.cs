using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number of the institutions : ");
            string line = Console.ReadLine();
            int n = int.Parse(line);

            Console.Write("Commands : ");
            int[] commands = new int[n];
            line = Console.ReadLine();
            string[] tokens = line.Split(' ');
            for (int count = 0; count < n; count++)
            {
                commands[count] = int.Parse(tokens[count]);
            }

            Console.Write("Classrooms : ");
            line = Console.ReadLine();
            int k = int.Parse(line);
            int result = default(int);
            for (int count = 0; count < n; count++)
            {
                if (commands[count] <= k)
                    result += commands[count];
                else
                    result += k;
            }

            Console.WriteLine("Answer : {0}", result);
            Console.ReadLine();
        }
    }
}

