using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDApple
{
    class Program
    {
        static void Main(string[] args)
        {
            
             var mother = new Parent("Maria", 24,Sex.Female);
             var father = new Parent("Alexander",29,Sex.Male);
             var daughter = new Children("Anna",4,Sex.Female);

            mother.DoSomething();
           

        }
            
        
    }
}
