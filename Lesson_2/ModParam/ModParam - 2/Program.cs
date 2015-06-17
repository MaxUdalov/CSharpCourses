using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModParam___2
{
    class Program
    {
        struct Points
        {
            public double x;
            public double y;

            //constructor
            public Points(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class Rectangular
        {
            //fields
            public double x,x1;
            public double y,y1;
            //propertes

            //constructor
            public Rectangular(Points x, Points y)
            {
                this.x = x.x;
                this.y = x.y;
                this.x1 = y.x;
                this.y1 = y.y;
            }
            public Rectangular()
            {

            }
            //methods
        }

   
        static void Main(string[] args)
        {
            Points Pnt1 = new Points(1,0);
            Points Pnt2 = new Points(5,3);
            Points Pnt3 = new Points(3,0);
            Points Pnt4 = new Points(7,2);
            Rectangular Rec = new Rectangular(Pnt1, Pnt2);
            Rectangular Rec1 = new Rectangular(Pnt3, Pnt4);
            Rectangular ResRec = new Rectangular();
            Rectangular ResRec1 = new Rectangular();
            string test = "(" + Pnt1.x.ToString() + " , " + Pnt1.y.ToString() + ") " + "&" + " (" + Pnt2.x.ToString() + " , " + Pnt2.y.ToString() + ")";
            double result = default(double);

            TryParse(test, out result);
            Console.WriteLine("Distance between {0} = {1}",test , Math.Round(result,1));

            ResRec = Cross(Rec, Rec1);
            Console.WriteLine("Cross Rectangulares : ({0} , {1}) & ({2} , {3} )", ResRec.x.ToString(),ResRec.y.ToString(),ResRec.x1.ToString(),ResRec.y1.ToString());

            Pnt1 = new Points(-2, 3);
            Pnt2 = new Points(5, 9);
            Pnt3 = new Points(-6, 1);
            Pnt4 = new Points(8, 8);
            Rec = new Rectangular(Pnt1, Pnt2);
            Rec1 = new Rectangular(Pnt3, Pnt4);
            ResRec1 = Includ(Rec, Rec1);
            Console.WriteLine("Includ Rectangulares : ({0} , {1}) & ({2} , {3} )", ResRec1.x.ToString(), ResRec1.y.ToString(), ResRec1.x1.ToString(), ResRec1.y1.ToString());

            Points p = new Points(0,0);
            PointsPosition(ResRec1, ref p);
            Console.WriteLine("Points Position : ({0} , {1})", p.x, p.y);

            Console.ReadLine();

        }
        static bool TryParse(string line, out double result)
        {
            string[] A = line.Split(new char[] { '(', ')', '&', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                result = Math.Sqrt(Math.Pow((double.Parse(A[3]) - double.Parse(A[0])), 2) + Math.Pow((double.Parse(A[5]) - double.Parse(A[2])), 2));
            }
            catch (Exception) { result = default(double); return false; }
            return true;
        }
        static Rectangular Cross(params Rectangular[] line)
        {
            Rectangular ResRec;
            ResRec = line[0];
            for (int count = 0; count < line.Count() - 1; count++)
            {
                if (line[count + 1].x < ResRec.x)
                    ResRec.x = line[count + 1].x;
                if (line[count + 1].y < ResRec.y)
                    ResRec.y = line[count + 1].y;
                if (line[count + 1].x1 > ResRec.x1)
                    ResRec.x1 = line[count + 1].x1;
                if (line[count + 1].y1 > ResRec.y1)
                    ResRec.y1 = line[count + 1].y1;
            }
            return ResRec;
        }
        static Rectangular Includ(params Rectangular[] line)
        {
            Rectangular ResRec;
            ResRec = line[0];
            for (int count = 0; count < line.Count() - 1; count++)
            {
                if (line[count + 1].x < ResRec.x)
                    ResRec.x = line[count + 1].x;
                if (line[count + 1].y < ResRec.y)
                    ResRec.y = line[count + 1].y;
                if (line[count + 1].x1 > ResRec.x1)
                    ResRec.x1 = line[count + 1].x1;
                if (line[count + 1].y1 > ResRec.y1)
                    ResRec.y1 = line[count + 1].y1;
            }
            return ResRec;
        }
        static void PointsPosition(Rectangular line, ref Points p)
        {
            if ((p.x < line.x) | (p.x > line.x1) | (p.x < line.y) | (p.y > line.y1))
            {
                p.x = (line.x + line.x1) / 2;
                p.y = (line.y + line.y1) / 2;
            }
        }
    }
}
