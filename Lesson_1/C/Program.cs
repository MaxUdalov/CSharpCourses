using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сумма_максимума_и_минимума___С
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input data : ");
            string line = Console.ReadLine();
            string[] tokens = line.Split(' ');

            int min = int.Parse(tokens[0]),
                max = int.Parse(tokens[1]);

            for (int count = 2; count < tokens.Length - 1; count++)
            {
                if (count % 2 == 0)
                {
                    if (min > int.Parse(tokens[count]))
                        min = int.Parse(tokens[count]);
                }
                else
                    if (max < int.Parse(tokens[count]))
                        max = int.Parse(tokens[count]);
            }

            Console.WriteLine("Answer : {0}", max + min);
            Console.ReadLine();
        }
    }
}
