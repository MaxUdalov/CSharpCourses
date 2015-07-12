using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Using_generic_Dictionaries
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Point() { }
        public override bool Equals(Object point)
        {
            if (point is Point)
            {
                if (this.X == ((Point)point).X && this.Y == ((Point)point).Y)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public override string ToString()
        {

            return string.Format("X = {0}\t Y = {1}", X, Y);
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
 
    class Program
    {
        static public void RandomForObjects(Hashtable map, int sum)
        {
            Random rnd = new Random();
            for (int i = 0; i < sum; i++)
                map.Add(new Point(rnd.Next(1, 100), rnd.Next(1, 100)),i);
        }
        static void Main(string[] args)
        {
            Hashtable Map = new Hashtable();
            Map.Add(new Point(1,2),"value");
            Console.Write("\t\tInput date!!!\n\tX = ");
            int X = int.Parse(Console.ReadLine());
            Console.Write("\n\tY = ");
            int Y = int.Parse(Console.ReadLine());
            bool a = false;
            foreach (DictionaryEntry s in Map)
                if (s.Key.Equals(new Point(X, Y)))
                    a = true;
            Console.Write("\tAnswer : ");
            if (a) Console.WriteLine(X);
            else Console.WriteLine((char)X);
                Console.ReadLine();
        }
    }
}
