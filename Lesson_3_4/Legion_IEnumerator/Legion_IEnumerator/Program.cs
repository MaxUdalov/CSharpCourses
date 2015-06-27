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
            private static string[] soldiers = new string[36];
            
            public IEnumerator GetEnumerator()
            {
                return soldiers.GetEnumerator();
            }
            internal class Square
            {
                public Square()
                {
                    for (int count = 0; count < soldiers.Length; count++)
                        soldiers[count] = "SOLDIER";
                }
                public IEnumerator GetEnumerator()
                {
                    for(int count = 0; count < soldiers.Length; count++)
                    {
                        if (count % 6 == 0)
                            yield return "\n";
                        yield return soldiers[count];
                    }
                }
            }
            internal class Rhombus : IEnumerable
            {
                public Rhombus()
                {
                    for (int count = 0; count < soldiers.Length; count++)
                        soldiers[count] = "SOLDIER";
                } 
                 
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return (IEnumerator)GetEnumerator();
                }

                public RhombusEnum GetEnumerator()
                {
                    return new RhombusEnum();
                }
                public class RhombusEnum : IEnumerator
                {
                    private int position = -1;
                    int index = 2;
                    int index1 = 5;
                    int i = 1;
                    public bool MoveNext()
                    {                       
                        position++;
                        if (position == i & position <21)
                        {                               
                            i += index;
                            index++;
                            Console.WriteLine();                             
                        }
                        if (position == i & position >= 21)
                        {
                           
                            i += index1;
                            index1--;
                            Console.WriteLine();
                        }
                        return (position < soldiers.Length);
                    }

                    public void Reset()
                    {
                        position = -1;
                    }

                    object IEnumerator.Current
                    {
                        get
                        {
                            return Current;
                        }
                    }

                    public string Current
                    {
                        get
                        {
                            try
                            {
                                return soldiers[position];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                }
            }
        }
    

   

        static void Main(string[] args)
        {
            //Legion.Square square = new Legion.Square();
            //foreach (var soldiers in square)
            //    Console.Write(soldiers + " ");

            Legion.Rhombus rhombus = new Legion.Rhombus();
            foreach (var soldiers in rhombus)
                Console.Write("\t" + soldiers);
       


            Console.ReadLine();
        }
    }
}
