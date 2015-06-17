using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModParam___1
{
    class Program
    {
        struct Points
        {
            //fields
            public int x;
            public int y;
            // constructor
            public Points(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }    
 
            static bool TryParse(string line, out int result)
            {
                result = default(int);
                string[] tokens = line.Split(',', '[', '(', ')', ']');
                if ((line[0] == '(' & line[line.Length - 1] == ']') || (line[0] == '[' & line[line.Length - 1] == ')'))
                {
                    result = Math.Abs(int.Parse(tokens[1]) - int.Parse(tokens[2]));
                    return true;
                }
                else
                {
                    if (line[0] == '(')
                        result = Math.Abs(int.Parse(tokens[1]) - int.Parse(tokens[2]))-1;
                    else
                        result = Math.Abs(int.Parse(tokens[1]) - int.Parse(tokens[2]))+1;
                    return true;
                }
                return false;               
            } 
            static bool Hit(int N ,  params Points[] test)   
            {
                string line;
                string[] tokens;
                int max = default(int),
                    min = default(int);
                for (int count = 0; count < test.Count(); count++)
                {
                    line = "[" + test[count].x.ToString() + "," + test[count].y.ToString() + "]";
                    tokens = line.Split(',', '[', '(', ')', ']');
                    bool position = default(bool);
                    if (int.Parse(tokens[1]) >= int.Parse(tokens[2]))
                    {
                        max = int.Parse(tokens[1]); 
                        min = int.Parse(tokens[2]);
                        position = true;

                    }
                    else
                    {
                        min = int.Parse(tokens[1]);
                        max = int.Parse(tokens[2]);
                    }
                    tokens = line.Split('1','2','3','4','6','5','7','8','9');
                    if ((tokens[0]== "(") & (tokens[2] == ")"))
                    {
                        if ((N < max) & (N > min))
                        {
                            Console.WriteLine("Answer : True!!!");
                            return true;
                        }
                    }
                    if ((tokens[0] == "[") & (tokens[2] == "]"))
                    {
                        if ((N <= max) & (N >= min))
                        {
                            Console.WriteLine("Answer : True!!!");
                            return true;
                        }
                    }
                    if ((tokens[0] == "(") & (tokens[2] == "]"))
                    {
                        if (position)
                        {
                            if ((N < max) & (N >= min))
                            {
                                Console.WriteLine("Answer : True!!!");
                                return true;
                            }
                        }
                        else
                            if ((N <= max) & (N > min))
                            {
                                Console.WriteLine("Answer : True!!!");
                                return true;
                            }

                    }
                    if ((tokens[0] == "[") & (tokens[2] == ")"))
                    {
                        if (position)
                        {
                            if ((N <= max) & (N > min))
                            {
                                Console.WriteLine("Answer : True!!!");
                                return true;
                            }
                        }
                        else
                            if ((N < max) & (N >= min))
                            {
                                Console.WriteLine("Answer : True!!!");
                                return true;
                            }
                    }                                    
                }
                Console.WriteLine("Answer : False!!!");
                return false;                
            }

        static void Main(string[] args)
        {
            Points points;
            points.x = 2;
            points.y = 6;
            Points points1 = new Points(7,8);

            Hit(1, points, points1);
           
            string test = "[" + points.x.ToString() + "," + points.y.ToString() + "]";
            int result = default(int);
            if (TryParse(test, out result))
                Console.WriteLine("Length between {0} = {1}", test, result);
            else
                Console.WriteLine("Incorrect data!");
            Console.ReadLine();
        }
    }
}
