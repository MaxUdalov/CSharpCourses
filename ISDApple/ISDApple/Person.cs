using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDApple
{
    enum Sex { Male,Female};
    class Person
    {
        int age;
        string name;
        public Sex sex;
        public string Name 
        {
            get { return name; }
            set
            {
                if (char.IsUpper(value.First()))
                    name = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int Age 
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 120)
                    age = value;
                else
                    throw new ArgumentOutOfRangeException();
            } 

        }
        public int MyProperty { get; set; }
        public override string ToString()
        {
            return string.Format("Name : {0}  Age : {1} Sex : {2}", Name, Age,sex);
        }
    }
    
}
