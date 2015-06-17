using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Решето_Эратосфена___Е
{

    class Program
    {
        public static void SimpleValue(int x)
        {
            if ((x % 2 != 0 && x % 3 != 0 && x % 3 != 0 && x % 5 != 0 && x % 7 != 0) | (x == 2) | (x == 3) | (x == 5) | (x == 7))//ничего больше не придумал
            {
                Console.Write(" {0}", x);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Input data : ");
            string line = Console.ReadLine();
            int N = int.Parse(line);

            Console.Write("Output data :");
            for (int value = 2; value <= N; value++)
                SimpleValue(value);
            Console.ReadLine();
        }

    }
}
