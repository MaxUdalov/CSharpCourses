using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input data : ");
            string line = Console.ReadLine();
            int N = default(int), result = 1;

            if (int.TryParse(line, out N))
            {
                while (N >= 1)
                {
                    result *= N;
                    N -= 2;
                }
            }
            else
            {
                Console.WriteLine("incorrect data!!");
                result = 0;
            }
            Console.WriteLine("Answer : {0}", result);
            Console.ReadLine();
        }
    }
}
