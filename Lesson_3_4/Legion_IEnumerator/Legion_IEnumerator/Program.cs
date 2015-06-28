using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IEnumerator
{
    class Program
    {
        class Legion : IEnumerable
        {
            int[] _legion;
            public Legion(int[] param)
            {
                _legion = param;
            } //constructor

            public enum LegionFormation
            {
                Square,
                Wedge,
                Rhombus
            };
            public LegionFormation Formation;
            public IEnumerator GetEnumerator()
            {
                switch (Formation.ToString())
                {
                    case "Square": return new Square(this); 
                    case "Wedge": return new Wedge(this); 
                    case "Rhombus": return new Square(this); // сделать с yield return
                    default: return (IEnumerator)GetEnumerator(); //никогда не попадаем
                }
            }
            class Square : IEnumerator
            {
                Legion _l;
                int position = -1;
                int[] kare = new int[6];
                public Square(Legion l) { _l = l; }

                public object Current
                {
                
                    get
                    {
 
                        Array.ConstrainedCopy(_l._legion, position+6, kare, 0, 6);
                        return kare;
                    }
                }
       

                public bool MoveNext()
                {
                    position++;
                    return (position < kare.Length);      
                }

                public void Reset()
                {
                    position = -1;
                }
            }
            class Wedge : IEnumerator
            {
                Legion _l;
                int position = -1;
                public Wedge(Legion l) { _l = l; }

                public object Current
                {

                    get
                    {
                        return _l._legion[position];
                    }
                }


                public bool MoveNext()
                {
                    position++;
                    if (position < _l._legion.Length)
                        return true;
                    else
                        return false;
                }

                public void Reset()
                {
                    position = -1;
                }
            }
        }
    

   

        static void Main(string[] args)
        {
            int[] FirstLegion = new int[36];
            for (int count = 0; count < FirstLegion.Length; count++)
                FirstLegion[count] = 1;
            Legion legion = new Legion(FirstLegion)
            {
                Formation = Legion.LegionFormation.Square
            };
            foreach (var s in legion)

                Console.WriteLine(string.Join(" ",(s as int[])));
            
            Console.ReadLine();
        }
    }
}
