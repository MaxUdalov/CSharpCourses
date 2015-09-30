using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDApple
{
    delegate void SimpleDelegate();
    class Parent : Person, IDoSomething
    {
        
        public event SimpleDelegate GoWorking;  

        public Parent(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.sex = sex;
        }
        public virtual void DoSomething()
        {
                Console.WriteLine("{0} is working!!!", this.Name);
                if (GoWorking != null)
                    GoWorking.Invoke();
        }
    }
}
