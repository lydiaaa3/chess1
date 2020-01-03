using System;
namespace chesstest.Properties
{
    public class Board
    {
        public Pieces[,] chessBoard = new Pieces[10, 9];
        private string blackJiang = $"[{9},{4}]";
        private string redShuai = $"[{0},{4}]";

        public Board()
        {
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

        public void jiangjun(int color)
        {
            string cm_red = "";
            string cm_black = "";
            bool Jiangjun = false;
            if (redShuai.Substring(3, 1) == blackJiang.Substring(3, 1))   //
            {
                Jiangjun = true;
                int n = Convert.ToInt32(redShuai.Substring(3, 1));
                int yblack = Convert.ToInt32(blackJiang.Substring(1, 1));
                int yred = Convert.ToInt32(redShuai.Substring(1, 1));

                for (int i = yred + 1; i < yblack; i++)
                {
                    if (chessBoard[i, n] != null)
                    {
                        Jiangjun = false;
                    }
                }

            }  //

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
            if (cm_black.IndexOf(redShuai, StringComparison.Ordinal) >= 0 | (Jiangjun & (color == 1)))
            {
                Console.WriteLine("（red）将军！");
            }
            if (cm_red.IndexOf(blackJiang, StringComparison.Ordinal) >= 0 | (Jiangjun & (color == -1)))
            {
                Console.WriteLine("（black）将军！");
            }

        }

        public void Display(string can_move)
        {
            Console.WriteLine();


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Console.BackgroundColor = ConsoleColor.Yellow;
                    if (can_move.IndexOf($"[{i},{j}]", StringComparison.Ordinal) >= 0)
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
            int color = 1;
            while (start)
            {
                if (color == 1)
                {
                    Console.Write("(red)");
                }
                else
                {
                    Console.Write("(black)");
                }
                Console.WriteLine("which piece do you want to move?");
                string chesspiece = Console.ReadLine();
                int x = Convert.ToInt32(chesspiece.Substring(1, 1));
                int y = Convert.ToInt32(chesspiece.Substring(3, 1));
                if (chessBoard[x, y] == null)
                {
                    Console.WriteLine("choose the right piece, si vous plait.");
                }
                else if ((color == 1) == (chessBoard[x, y].GetColor()))
                {
                    Console.WriteLine("choose the right piece, si vous plait.");
                }
                else
                {
                    string can_move = chessBoard[x, y].Option(chessBoard, x, y);
                    this.Display(can_move);
                    if (can_move.Length < 5)
                    {
                        Console.WriteLine("There is no way you can go.");
                    }
                    else
                    {
                        Console.WriteLine(can_move);
                        Console.WriteLine("where do you want to move?");
                    }
                    string newposition = Console.ReadLine();
                    int nx = Convert.ToInt32(newposition.Substring(1, 1));
                    int ny = Convert.ToInt32(newposition.Substring(3, 1));
                    if (can_move.IndexOf(newposition, StringComparison.Ordinal) >= 0)
                    {
                        if (chessBoard[nx, ny] != null)
                        {
                            if (chessBoard[nx, ny].name == "将")
                            {
                                start = false;
                                if (color == 1)
                                {
                                    Console.WriteLine("red win");
                                    blackJiang = "      ";
                                }
                                else
                                {
                                    Console.WriteLine("black win");
                                    redShuai = "       ";
                                }
                            }
                        }
                        chessBoard[nx, ny] = chessBoard[x, y];
                        if (chessBoard[nx, ny].name == "将")
                        {
                            if (color == 1)
                            {
                                redShuai = $"[{nx},{ny}]";
                            }
                            else
                            {
                                blackJiang = $"[{nx},{ny}]";
                            }
                        }
                        chessBoard[x, y] = null;
                        jiangjun(color);
                        color = color * (-1);
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
