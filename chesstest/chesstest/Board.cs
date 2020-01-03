using System;
using System.Collections;

namespace chesstest.Properties
{
    public class Board
    {
        public Pieces[,] chessBoard = new Pieces[10, 9];
        private string blackJiang;
        private string redShuai;
        private string cm_red = "";  
        private string cm_black = "";  
        private string Move = "";   
        //private string lastBlackMove="";
        private ArrayList Cover = new ArrayList();
        //private Pieces lastBlackCover;
        private bool blackChecked = false;
        private bool redChecked = false;

        public Board()
        {
            blackJiang = $"{9},{4}";
            redShuai = $"{0},{4}";
            bool color = false;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    chessBoard[9 * i, 8 * j] = new Che(color);
                    chessBoard[9 * i, 6 * j + 1] = new Ma(color);
                    chessBoard[9 * i, 4 * j + 2] = new Xiang(color);
                    chessBoard[9 * i, 2 * j + 3] = new Shi(color);
                    chessBoard[5 * i + 2, 6 * j + 1] = new Pao(color);
                }
                for (int j = 0; j < 5; j++)
                {
                    chessBoard[3 * i + 3, 2 * j] = new Bing(color);
                }
                chessBoard[9 * i, 4] = new Jiang(color);
                color = true;
            }
        }


        public void check()
        {
            //if (redShuai.Substring(2, 1) == blackJiang.Substring(2, 1))   //将军在同一列
            //{
            //    Jiangjun = true;
            //    int n = Convert.ToInt32(redShuai.Substring(2, 1));
            //    int yblack = Convert.ToInt32(blackJiang.Substring(0, 1));
            //    int yred = Convert.ToInt32(redShuai.Substring(0, 1));
            //    for (int i = yred + 1; i < yblack; i++)
            //    {
            //        if (chessBoard[i, n] != null)
            //        {
            //            Jiangjun = false;
            //        }
            //    }
            //} 

            if (cm_black.IndexOf(redShuai, StringComparison.Ordinal) >= 0)
            {
                redChecked = true;
                //Console.WriteLine("（red）将军！");
            }
            if (cm_red.IndexOf(blackJiang, StringComparison.Ordinal) >= 0)
            {
                blackChecked = true;
                //Console.WriteLine("（black）将军！");
            }
            else
            {
                redChecked = false;
                blackChecked = false;
            }
        }

        public void collectOption()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (chessBoard[i, j] != null)
                    {
                        if (chessBoard[i, j].GetColor())
                        {
                            cm_black += chessBoard[i, j].Option(chessBoard, i, j);
                        }
                        else
                        {
                            cm_red += chessBoard[i, j].Option(chessBoard, i, j);
                        }
                    }
                }
            }
        }

        public bool checkmate(bool color)
        {


            //bool checkmate = true;
            //Pieces premove;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((chessBoard[i,j]!=null) && (chessBoard[i, j].GetColor() != color))
                    {
                        string canMove = chessBoard[i, j].Option(chessBoard,i,j);
                        int l = canMove.Length/3;
                        for(int k = 0; k < l; k++)
                        {
                            int x = Convert.ToInt32(canMove.Substring(k*3+0, 1));
                            int y = Convert.ToInt32(canMove.Substring(k*3+2, 1));
                            move(i, j, x, y);
                            check();
                            unDo();
                            if (!(color & redChecked | !color & blackChecked))
                            //{
                            //    //this.Display("");
                            //}
                            //else
                            {
                                return false;
                            }
                        }
                    }   
                }
            }
            return true;
        }
        public void unDo()
        {
            int x = Convert.ToInt32(Move.Substring(0, 1));
            int y = Convert.ToInt32(Move.Substring(2, 1));
            int nx = Convert.ToInt32(Move.Substring(3, 1));
            int ny = Convert.ToInt32(Move.Substring(5, 1));
            chessBoard[x, y] = chessBoard[nx, ny];
            int l = Cover.Count;
            chessBoard[nx, ny] = (Pieces)Cover[l - 1];
            Cover.RemoveAt(l - 1);
            Move = Move.Substring(6);
            //collectOption();
        }

        public void move(int x,int y,int nx,int ny)  //弄个默认值 如果是false就是悔棋
        {
            //store the last move;
            Move = x + "," + y + nx + "," + ny + Move;
            Cover.Add(chessBoard[nx, ny]);
            //switch
            chessBoard[nx, ny] = chessBoard[x, y];
            chessBoard[x, y] = null;
            

            if (chessBoard[nx, ny].GetName() == "将")
            {
                if (chessBoard[nx,ny].GetColor())
                {
                    redShuai = $"{nx},{ny}";
                }
                else
                {
                    blackJiang = $"{nx},{ny}";
                }
            }
            collectOption();
        }


        public void Display(string can_move)
        {
            Console.WriteLine();


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Console.BackgroundColor = ConsoleColor.Yellow;
                    if (can_move.IndexOf($"{i},{j}", StringComparison.Ordinal) >= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;

                    }
                    if (chessBoard[i, j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("+ ");
                    }
                    else
                    {
                        chessBoard[i, j].Display();
                    }
                    Console.ResetColor();
                }

                Console.WriteLine();
                //Console.BackgroundColor = ConsoleColor.Yellow;
                if (i == 4)
                {
                    Console.WriteLine("                  ");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }


        public void game()
        {
            bool start = true;
            bool color = false;
            while (start)
            {
                if (color)
                {
                    Console.Write("(black)");
                }
                else
                {
                    Console.Write("(red)");
                }
                Console.WriteLine("which piece do you want to move?");
                string chesspiece = Console.ReadLine();
                int x = Convert.ToInt32(chesspiece.Substring(0, 1));
                int y = Convert.ToInt32(chesspiece.Substring(2, 1));
                if (chessBoard[x, y] == null|| (!color) == (chessBoard[x, y].GetColor()))
                {
                    Console.WriteLine("choose the right piece, si vous plait.");
                }
                else
                {
                    string can_move = chessBoard[x, y].Option(chessBoard, x, y);
                    this.Display(can_move);
                    if (can_move.Length < 3)
                    {
                        Console.WriteLine("There is no way you can go.");
                    }
                    else
                    {
                        Console.WriteLine(can_move);
                        Console.WriteLine("where do you want to move?");
                    }
                    string newposition = Console.ReadLine();
                    int nx = Convert.ToInt32(newposition.Substring(0, 1));
                    int ny = Convert.ToInt32(newposition.Substring(2, 1));
                    if (can_move.IndexOf(newposition, StringComparison.Ordinal) >= 0)
                    {
                        if (chessBoard[nx, ny] != null)
                        {
                            if (chessBoard[nx, ny].GetName() == "将")
                            {
                                start = false;
                                if (color)
                                {
                                    Console.WriteLine("black win");
                                    redShuai = "       ";
                                }
                                else
                                {
                                    Console.WriteLine("red win");
                                    blackJiang = "      ";
                                }
                            }
                        }
                        move(x,y,nx,ny);
                        check();
                        if ((color & blackChecked)|(!color & this.checkmate(color)))
                        {
                            Console.WriteLine("red win");
                            start = false;
                        }
                        if ((!color & redChecked) | (color & this.checkmate(color)))
                        {
                            Console.WriteLine("black win");
                            start = false; 
                        }
                        color = !color;
                    }
                    else
                    {
                        Console.WriteLine("choose the right position, si vous plait.");
                    }
                    this.Display("");
                }
            }
        }
    }
}
