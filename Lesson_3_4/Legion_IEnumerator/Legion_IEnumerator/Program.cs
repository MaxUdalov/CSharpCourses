using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IEnumerator
{
    class Legion : IEnumerable
    {
        int[] _legion;
        public Legion(int[] param)
        {
            _legion = param;
        } //constructor
        public int[] GetLegion()
        {
            return _legion;
        }
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
                case "Rhombus": return GetRhombusEnumerator(); // сделать с yield return
                default: throw new NotImplementedException(); //никогда не попадаем
            }
        }
        public IEnumerator GetRhombusEnumerator()
        {
            int position = 0;
            int length = 1;
            for(int count = 0 ; count < 11 ; count++)
            {
                int[] _m = new int[length];
                if (position < 21)
                { 
                    Array.ConstrainedCopy(_legion, position, _m, 0, length);
                    length++;            
                }
                else
                {
                    Array.ConstrainedCopy(_legion, position, _m, 0, length);
                    length--;
                }
                position += _m.Length;
                if (position == 21) length -= 2;
                yield return _m;
            }
        }
        public int this[int index]
        {
            get { return _legion[index-1]; }
        }
        public int this[int row, int position]
        {   
            get 
            {
                try
                {
                    switch (Formation.ToString())
                    {
                        case "Square": return _legion[(row - 1) * 6 + position - 1];
                        case "Wedge": return _legion[row];
                        case "Rhombus": return _legion[row];
                        default: throw new NotImplementedException(); //никогда не попадаем
                    }
                }
                catch (IndexOutOfRangeException) { return -1; }
            }
        }
 
           
        class Square : IEnumerator
        {
            Legion _l;
            int position = -1;
            int[][] _new = new int [6][];
            public int[][] GetSquare()
            {
                return _new;
            }
            public Square(Legion l) { _l = l; }
            public object Current
            {

                get
                {
                    int[] kare = new int[6];
                    Array.ConstrainedCopy(_l._legion, position * 6, kare, 0, 6);
                    return kare;
                }
            }

            public bool MoveNext()
            {
                position += 1;
                return (position < 6);
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
            int index = 0;
            public Wedge(Legion l) { _l = l; }

            public object Current
            {

                get
                {
                    int[] _m = new int[position+1];                  
                    Array.ConstrainedCopy(_l._legion, index, _m, 0, position + 1);
                    index += _m.Length;
                    return _m;
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < 8);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
    class Program
    { 

        static void Main(string[] args)
        {
            int[] FirstLegion = new int[36];
            for (int count = 0; count < FirstLegion.Length; count++)
                FirstLegion[count] = count + 1;
            Legion legion = new Legion(FirstLegion)
            {
                Formation = Legion.LegionFormation.Rhombus
            };
            foreach (var l in legion)
            {
                Console.WriteLine(string.Join(" ", l as int[]));
            }
            int k = legion[10, 2];
            Console.ReadLine();
            
        }
    }
}
