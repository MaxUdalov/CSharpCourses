using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    class Product
    {
        public Product() { }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Characteristics { get; set; }
        public string FileName { get; set; }
        public override string ToString()
        {
            return string.Format("\nFileName : {0}\nProduct type : {1}\nName : {2}\nCharacteristics :\n{3}\n",
                                FileName, ProductType, Name, Characteristics);
        }
    }
}
