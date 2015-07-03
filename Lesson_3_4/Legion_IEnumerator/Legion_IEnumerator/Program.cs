using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IEnumerator
{
    class Solders
    {
        public readonly string[] first_name = { "Вася", "Петя", "Геракл", "Кузьма", "Володя", "Степан" };
        public readonly string[] last_name = { "Тумбочка", "Сидоров", "Мужицкий", "Леший", "Крабов", "Вазовски" };
        public Solders[] AddSoldiers()
        {
            Random rnd = new Random();
            Solders[] sld = new Solders[36];
            for (int count = 0; count < 36; count++)
            {

                sld[count].Name = sld[0].first_name[rnd.Next(0, 6)] + " " + sld[0].last_name[rnd.Next(0, 6)];
                sld[count].Age = rnd.Next(18, 60);
            }
            return sld;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Legion : IEnumerable
    {
        Solders[] _legion;
        public Legion(Solders[] param)
        {

            _legion = param;
            
        } //constructor     
        public Solders[] GetLegion()
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
        public Solders this[int index]
        {
            get {
                if (index > _legion.Length) throw new IndexOutOfRangeException();
                    return _legion[index-1]; 
                }
        }
        public Solders this[int row, int position]
        {   
            get 
            {
                
                    switch (Formation)
                    {
                        case LegionFormation.Square: if (row > 6 && position > 6) throw new IndexOutOfRangeException();
                                                     return _legion[(row - 1) * 6 + position - 1];
                        case LegionFormation.Wedge: if (position > row && position > 8) throw new IndexOutOfRangeException();
                                                    int elements = 0;
                                                    for (int i = 1; i < row ; i++)
                                                        elements += i;
                                                    return _legion[elements + position - 1];
                        case LegionFormation.Rhombus: if (row > 11 && position > 6) throw new IndexOutOfRangeException();
                                                      elements = 0;
                                                      int newrow = 1;
                                                      while (newrow <= 6)
                                                      {
                                                          if (position > row) throw new IndexOutOfRangeException();
                                                          elements += newrow;
                                                          newrow++;
                                                      }
                                                      if (row > 6)
                                                      {
                                                          int default_pos = 5;
                                                          for (int i = 7; i < row; i++)
                                                          {
                                                              if (i > default_pos) throw new IndexOutOfRangeException();
                                                              elements += default_pos;
                                                              default_pos--;
                                                          }
                                                      }
                                                                                                        
                                                      return _legion[elements + position - 1];
                        default: throw new NotImplementedException(); //никогда не попадаем
                    }
                
            }
        }
        public Solders this[string name]
        {
            
            get
            {
                
                for (int i = 0; i < _legion.Length; i++)
                        if (_legion[i].Name == name) return _legion[i];
                throw  new IndexOutOfRangeException();
            }
        }
        class Square : IEnumerator
        {
            Legion _l;
            int position = -1;
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

            Solders sld = new Solders();
           
            Legion legion = new Legion(sld.AddSoldiers())
            {
                Formation = Legion.LegionFormation.Rhombus
            };
           
            foreach (var l in legion)
            {
                Console.WriteLine(string.Join(" ", l as int[]));
            }
            Console.WriteLine(legion["Вася Тумбочка"]);
            Console.ReadLine();
            
        }
    }
}
