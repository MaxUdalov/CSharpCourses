using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    class Manager
    {
        string path;
        List<Product> products = new List<Product>();
        public Manager(string path)
        {
            this.path = path;
        }
        public Manager() { }
        [Employed]
        public List<Product> GetPhonesWithWeightMoreThan(double weight)
        {
            return GetPhones().
                Where(n => double.Parse(n.Characteristics.Split(new string[] { "Масса:" }, StringSplitOptions.RemoveEmptyEntries)[1]) > weight)
                .ToList();
        }
        [Employed]
        public List<Product> GetAllProductsInfo()
        {
            return products;
        }
        [Employed]
        public List<Product> AddProduct(string path)
        {
            Dictionary<string, IParser> extParserMappings = new Dictionary<string, IParser>();
            extParserMappings.Add(".txt", new TxtParser());
            extParserMappings.Add(".html", new HtmlParser());
            var paths = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (var item in paths)
            {
                IParser parser;
                if (extParserMappings.TryGetValue(Path.GetExtension(item), out parser))
                    products.Add(parser.Parse(item));
            }
            return products;
        }
        [Employed]
        public int GetCount()
        {
            return products.Count();
        }
        [Employed]
        public List<Product> GetProductsContainingWord(string containingWord )
        {
            return products.Where(n => n.Characteristics.Contains(containingWord) || n.ProductType.Contains(containingWord)).ToList();
        }
        [Employed]
        public  List<Product> GetPhones() 
        {
            return products.Where(prod => prod.ProductType == "Phone").ToList();
        }
        [Employed]
        public List<Product> GetCoffeeBlenders()
        {
            return products.Where(prod => prod.ProductType == "Coffee Blender").ToList();
        }
    }
}
