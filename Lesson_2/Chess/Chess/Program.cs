using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        class Board
        {
            int x;
            int y;

            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value;}
            }

            public int GetSize(int x, int y)
            {
                return X * Y;
            }

            //constructor
            public Board(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public Board() { }

        }
        class ChessBoard : Board
        {
            // Method

            public int GetSize(int x)
            {
                return (int)Math.Pow(x,2);
            }
            public void IncSize(int x)
            {
                X += x;
            }
            //constructor
            public  ChessBoard(int x) 
            {
                this.X = x;
            }
        }
        class Figures
        {
            public enum VariousFigures
            {
                king = 0,   //Король
                queen = 1,  //Ферзь
                rook = 2,   //Ладья
                bishop = 3, //Слон
                knight = 4, //Конь
                pawn = 5  //Пешка
            }
            
            //properties
            public VariousFigures King
            {
                get { return VariousFigures.king; }
            }
            public VariousFigures Queen
            {
                get { return VariousFigures.queen; }
            }
            public VariousFigures Rook
            {
                get { return VariousFigures.rook; }
            }
            public VariousFigures Bishop
            {
                get { return VariousFigures.bishop; }
            }
            public VariousFigures Knight
            {
                get { return VariousFigures.knight; }
            }
            public VariousFigures Pawn
            {
                get { return VariousFigures.pawn; }
            }
           
            //methods
            public void Iam(VariousFigures figure)
            {
                Console.WriteLine("I am {0}", figure);
            }
            public void TakeAStep(VariousFigures figure)
            {
                /* */
            }

        }
        class ChessFigures : Figures
        {
            public int VariousFiguresCount()
            {

                return (int)VariousFigures.pawn + 1;
            }

            public void TakeAStep(VariousFigures figure)
            {
                switch (figure)
                {
                    case VariousFigures.king : /*king take a step*/ break;
                    case VariousFigures.queen : /*king take a step*/ break;
                    case VariousFigures.bishop : /*king take a step*/ break;
                    case VariousFigures.knight : /*king take a step*/ break;
                    case VariousFigures.pawn : /*king take a step*/ break;
                    case VariousFigures.rook : /*king take a step*/ break;
                    default: /*this figure cant take a step */ break;
                }
            }
            public VariousFigures SuperPawn()
            {
                Console.WriteLine("Make a choice :\nqueen\nrook\nbishop\nknight");
                string NewFigure = Console.ReadLine();   
                switch(NewFigure)
                {
                    case "queen": return VariousFigures.queen; break;
                    case "rook": return VariousFigures.rook; break;
                    case "bishop": return VariousFigures.bishop ;break;
                    case "knight": return VariousFigures.knight; break;
                    default: /*figure of this type does not exist*/ return VariousFigures.pawn; break;
                }                                                              
            }
        }


        static void Main(string[] args)
        {
            ChessBoard ChssBrd = new ChessBoard(10);
            ChssBrd.IncSize(10);
            Console.WriteLine("Size : {0}", ChssBrd.GetSize(ChssBrd.X).ToString());

            ChessFigures ChssFgr = new ChessFigures();
            ChssFgr.Iam(ChssFgr.King);
            Console.WriteLine("VariousFiguresCount = {0}", ChssFgr.VariousFiguresCount());
     
            Console.ReadLine();
        }
    }
}
