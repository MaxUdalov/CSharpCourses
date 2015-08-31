using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace FinalTest
{
    class Menu
    {
        List<MethodInfo> methods = new List<MethodInfo>();
        private void BuildMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            methods = typeof(FinalTest.Manager).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(n => n.GetCustomAttributes(false).Select(a => a.ToString() == typeof(Employed)
                .ToString()).FirstOrDefault()).ToList();
            methods.Add(typeof(Menu).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(n => n.GetCustomAttributes(false).Select(a => a.ToString() == typeof(Employed)
                .ToString()).FirstOrDefault()).FirstOrDefault());
            Console.WriteLine("\t\tMenu!!!");
            for(int i = 0; i < methods.Count; i++)
                Console.WriteLine("{0}: {1}",i+1,methods[i].Name);
            Console.Write("Your choice : ");
        }
        [Employed]
        private static void Exit()
        {
            return;
        }
        public static void EShop()
        {
            Menu menu = new Menu();
            Manager manager = new Manager();
            List<Product> products = new List<Product>();
            while (true)
            {
                menu.BuildMenu();
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
                                    Console.Write("Enter the weight for phones : ");
                                    foreach (var item in manager.GetPhonesWithWeightMoreThan(double.Parse(Console.ReadLine())))
                                        Console.WriteLine(item.ToString());
                                    break;
                                }
                            case 2:
                                {
                                    foreach (var item in manager.GetAllProductsInfo())
                                        Console.WriteLine(item.ToString());
                                    break;
                                }
                            case 3:
                                {
                                    Console.Write("Enter the path : ");
                                    products = manager.AddProduct(Console.ReadLine());
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Count : {0}", manager.GetCount());
                                   
                                    break;
                                }
                            case 5:
                                {
                                    Console.Write("Enter the contaiting word : ");
                                    foreach (var item in manager.GetProductsContainingWord(Console.ReadLine()))
                                        Console.WriteLine(item.ToString());
                                    break;
                                }
                            case 6:
                                {
                                    foreach (var item in manager.GetCoffeeBlenders())
                                        Console.WriteLine(item.ToString());
                                    break;
                                }
                            case 7:
                                {
                                    foreach (var item in manager.GetPhones())
                                        Console.WriteLine(item.ToString());                                   
                                    break;
                                }
                            case 8: 
                                return;
                            default:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Incorrect data!!!");
                                    break;
                                }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    Console.Write("Press any key!!");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}
