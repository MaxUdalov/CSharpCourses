using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    class TxtParser : IParser
    {
        public Product Parse(string path)
        {
            using (var strrd = new StreamReader(path, Encoding.Default))
            {
                var text = strrd.ReadToEnd();
                string[] split = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                Product product = new Product();
                product.FileName = Path.GetFileName(path);
                product.Name = split[0];
                product.Characteristics = split[1];
                if (split[1].Contains("Операционная система"))
                    product.ProductType = "Phone";
                else
                    product.ProductType = "Coffee Blender";
                return product;
            }
        }
    }
}
