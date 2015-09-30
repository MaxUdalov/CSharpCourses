using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDApple
{
     sealed class Children : Parent
    {
         public Children(string name, int age, Sex sex) : base(name, age, sex) 
         {
             base.GoWorking += () => Console.WriteLine("{0} going kindergarten",Name); // не работает
         }
        
         public override void DoSomething()
        {
            
            Console.WriteLine("{0} is walks!!!",this.Name);
        }
    }
}
