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
            switch (Formation)
            {
                case LegionFormation.Square : return new Square(this);
                case LegionFormation.Wedge : return new Wedge(this);
                case LegionFormation.Rhombus : return GetRhombusEnumerator(); // сделать с yield return
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
                Array.ConstrainedCopy(_legion, position, _m, 0, length);
                if (position < 21)          
                    length++;            
                else
                    length--;
                position += _m.Length;
                if (position == 21) length -= 2;
                yield return _m;
            }
        }
        public int this[int index]
        {
            get {
                if (index > _legion.Length) return -1;
                    return _legion[index-1]; 
                }
        }
        public int this[int row, int position]
        {   
            get 
            {
                
                    switch (Formation)
                    {
                        case LegionFormation.Square: if (row > 6 && position > 6) return -1;
                                                     return _legion[(row - 1) * 6 + position - 1];
                        case LegionFormation.Wedge: if (position > row && position > 8) return -1;
                                                    int elements = 0;
                                                    for (int i = 1; i < row ; i++)
                                                        elements += i;
                                                    return _legion[elements + position - 1];
                        case LegionFormation.Rhombus: if(row > 11 && position > 6) return -1;
                                                      elements = 0;
                                                      int newrow = 1;
                                                      int j = 1;
                                                      while (newrow <= 6)
                                                      {
                                                          if (position > row) return -1;
                                                          elements += newrow;
                                                          newrow++;
                                                      }
                                                      if (row > 6)
                                                      {
                                                          int default_pos = 5;
                                                          for (int i = 7; i < row; i++)
                                                          {
                                                              if (i > default_pos) return -1;
                                                              elements += default_pos;
                                                              default_pos--;
                                                          }
                                                      }
                                                                                                        
                                                      return _legion[elements + position - 1];
                        default: throw new NotImplementedException(); //никогда не попадаем
                    }
                
            }
        }
        public int this[string name]
        {
            get
            {
                int position;
                if (!int.TryParse(name, out position))
                    return -1;
                else
                {
                    for (int i = 0; i < _legion.Length; i++)
                        if (_legion[i] == position) return _legion[i];
                }
                return -1;
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
            int k = legion["37"];
            Console.WriteLine(k);
            Console.ReadLine();
            
        }
    }
}
