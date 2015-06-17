using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Разложение_числа___G
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input data : ");
            string line = Console.ReadLine();
            int N = int.Parse(line);

            int result = default(int),
                answer = default(int),
                megacount = default(int);
            bool dataready = default(bool);
            while (dataready != true)
            {
                megacount++;
                for (int count = megacount; result < N; count++)
                {
                    result += count;
                    answer++;
                    if (result == N)
                        dataready = true;
                }
                if (megacount == N)
                {
                    answer = 1;
                    dataready = true;
                }
                if (dataready == false)
                    answer = default(int);
                result = default(int);

            }
            Console.WriteLine("Answer : {0}", answer);
            Console.ReadLine();
        }
    }
}
