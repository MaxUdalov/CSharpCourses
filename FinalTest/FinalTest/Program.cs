using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows;

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
    interface IParser
    {
        Product Parse(string path);
    }
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
    class HtmlParser : IParser
    {

        public Product Parse(string path)
        {
            Product product = new Product();
            product.FileName = Path.GetFileName(path);
            string text;
            string[] split;
            string price = "";
            using (StreamReader strrd = new StreamReader(path))
            {
                text = strrd.ReadToEnd();
                if (text.Contains("Операционная система"))
                    product.ProductType = "Phone";
                else
                    product.ProductType = "Coffee Blender";
                split = text.Split(new string[] { "</a></em><br/>\n", "\n</h3>" }, StringSplitOptions.RemoveEmptyEntries);
                product.Name = split[1];
            }
            using (StreamReader strrd = new StreamReader(path))
            {
                while ((text = strrd.ReadLine()) != null)
                {
                    if (text.Contains("Средняя цена:"))
                    {
                        split = text.Split(new string[] { "<p>", "<br/>" }, StringSplitOptions.RemoveEmptyEntries);
                        price = split[1];
                        text = strrd.ReadLine();
                        split = text.Split(new string[] { "<b class=\"orng\">", "</b>&nbsp;(30 $)" }, StringSplitOptions.RemoveEmptyEntries);
                        price = price + " " + split[1];
                    }
                    if (text.Contains("Тип"))
                    {

                        StringBuilder strbld = new StringBuilder(product.Characteristics);
                        for (int i = 0; i < 11; i++)
                        {
                            split = text.Split(new string[] { "<td class=\"first\">", "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                            strbld.Append(split[1]);
                            text = strrd.ReadLine();
                            split = text.Split(new string[] { "<td><b>", "</b></td>" }, StringSplitOptions.RemoveEmptyEntries);
                            strbld.Append(": " + split[1] + "\n");
                            text = strrd.ReadLine(); text = strrd.ReadLine(); text = strrd.ReadLine();
                        }
                        product.Characteristics = strbld.ToString() + price;
                        break;
                    }
                }
            }
            return product;
        }
    }
    class Manager
    {
        string path;
        List<Product> products = new List<Product>();
        public Manager(string path)
        {
            this.path = path;
        }
        public Manager() { }
        public void GetPhonesWithWeightMoreThan(double weight)
        {
            foreach (var item in products)//vozmojen null
            {
                if (item.ProductType == "Phone")
                {
                    string[] split = item.Characteristics.Split(new string[] { "Масса:" }, StringSplitOptions.RemoveEmptyEntries);
                    if(double.Parse(split[1]) > weight)
                        Console.WriteLine(item.ToString());
                }
            }
        }
        public void GetAllProductsInfo()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public List<Product> AddProduct(string path)
        {
            Dictionary<string, IParser> vocabulary = new Dictionary<string, IParser>();
            vocabulary.Add(".txt", new TxtParser());
            vocabulary.Add(".html", new HtmlParser());
            var paths = Directory.EnumerateFiles(path);
            foreach (var item in paths)
            {
                IParser parser;
                if (vocabulary.TryGetValue(Path.GetExtension(item), out parser))
                    products.Add(parser.Parse(item));
            }
            return products;
        }
        public int GetCount()
        {
            return products.Count();
        }
        public void GetProductsContainingWord(string containingword )
        {
            foreach (var item in products)
            {
                if(item.Characteristics.Contains(containingword) || item.ProductType.Contains(containingword))
                    Console.WriteLine(item.ToString());
            }
        }
        public  void GetPhones() 
        {
            foreach (var item in products)
                if (item.ProductType == "Phone")
                    Console.WriteLine(item.ToString());
        }
        public void GetCoffeeBlenders()
        {
            foreach (var item in products)
                if (item.ProductType == "Coffee Blender")
                    Console.WriteLine(item.ToString());
        }


    }
    class Menu
    {
        public static void EShop()
        {
            Manager manager = new Manager();
            List<Product> products = new List<Product>();
            Console.WriteLine("\t\tWelcome!!!");
            while (true)
            {
                Console.WriteLine(" 1 - AddProducts\n 2 - GetAllProductsInfo\n 3 - GetPhonesWithWeightMoreThan");
                Console.WriteLine(" 4 - GetPhones\n 5 - GetCoffeeBlenders\n 6 - GetCount\n 7 - Exit");
                Console.Write("Your choice : ");
                int operation;
                if (int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.Clear();
                    try
                    {
                        switch (operation)
                        {
                            case 1:
                                {
                                    Console.Write("Enter the path : ");
                                    products = manager.AddProduct(Console.ReadLine());
                                    break;
                                }
                            case 2:
                                {
                                    manager.GetAllProductsInfo();
                                    break;
                                }
                            case 3:
                                {
                                    Console.Write("Enter the weight for phones : ");
                                    manager.GetPhonesWithWeightMoreThan(double.Parse(Console.ReadLine()));
                                    break;
                                }
                            case 4:
                                {
                                    manager.GetPhones();
                                    break;
                                }
                            case 5:
                                {
                                    manager.GetCoffeeBlenders();
                                    break;
                                }
                            case 6:
                                {
                                    Console.WriteLine("Count : {0}", manager.GetCount());
                                    break;
                                }
                            case 7:
                                return;
                            default:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Incorrect data!!!");
                                    break;
                                }
                        }
                    }
                    catch (Exception) { Console.WriteLine("Incorrect data!!!"); }
                    Console.Write("Press any key!!");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Menu.EShop();   
        }
    }
}
