using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    interface IParser
    {
        Product Parse(string path);
    }
}
