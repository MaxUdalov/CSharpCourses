using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator
{
    public delegate void CalcDelegate(double answer);
    public class Calculator
    {
        double answer;
        public double Answer
        {
            get { return answer; }
        }

        private static double InputDate()
        {
            string s;
            double number = 0;
            Console.Write("Input number : ");
            s = Console.ReadLine();
            if (double.TryParse(s, out number)) return number;
            throw new InvalidCastException();
        }
        private static int InputOperation()
        {
            int operation = 0;
            string s;
            Console.WriteLine("Input operation : \n1 - plus\n2 - minus\n3 - multiplication\n4 - division");
            s = Console.ReadLine();
            if (int.TryParse(s, out operation)) return operation;
            return 0;
        }
        private static bool NextOperation()
        {
            string newoperation;
            Console.Write("Do you want to perform another operation? (yes/no)");
            newoperation = Console.ReadLine();
            return (newoperation == "yes" || newoperation == "YES");
        }
        private static double PerformOperation(double x, double y, int operation)
        {
            switch (operation)
            {
                case 1: return x + y;
                case 2: return x - y;
                case 3: return x * y;
                case 4: if (y == 0) throw new DivideByZeroException(); return x / y;
                default: Console.WriteLine("This operation did not find!!!"); return 0;
            }
        }
        public void CalculatorRun()
        {
            while (true)
            {
                try
                {
                    answer = PerformOperation(InputDate(), InputDate(), InputOperation());
                    CalcEvent.Invoke(answer);
                }
                catch (DivideByZeroException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("incorrect information!!!"); }
                if (!NextOperation())
                    break;
                Console.Clear();
            }
        }
        public event CalcDelegate CalcEvent;      
    }
    public class ObsConsole 
    {
        public static void Event(double answer)
        {
            Console.WriteLine("Answer = {0}", answer );
        }
    }
    public class ObsFile 
    {
        public static void Event(double answer)
        {
            StreamWriter sw = new StreamWriter("result.txt");
            sw.Write(answer);
            sw.Close();
        }
    }
    class Program
    {
      
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.CalcEvent += ObsConsole.Event;
            calc.CalcEvent += ObsFile.Event;
            calc.CalculatorRun();
        }
    }
}
