using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Волосатый_бизнес___Н
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Days : ");
            string line = Console.ReadLine();
            int N = int.Parse(line);

            List<int> pricelist = new List<int>();
            Console.Write("\t\tPriceListByNEFORMAL");
            for (int count = 0; count < N; count++)
            {
                Console.Write("\n{0} Day: ", count + 1);
                line = Console.ReadLine();
                pricelist.Add(int.Parse(line));
            }
            int result = default(int),
                indexmax = default(int);

            indexmax = pricelist.IndexOf(pricelist.Max());
            while (pricelist.Count != 0)
            {
                result = result + (pricelist.Max() * (indexmax + 1));
                for (int count = 0; count < indexmax + 1; count++)
                    pricelist.RemoveAt(0);
                if (pricelist.Count > 0)
                    indexmax = pricelist.IndexOf(pricelist.Max());
            }
            Console.Write("Answer : {0}", result);
            Console.ReadLine();
        }
    }
}


