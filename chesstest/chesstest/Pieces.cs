using System;

namespace chesstest.Properties
{
    public class Bing : Pieces
    {
        public Bing(bool color)
            : base(color, "兵") { }


        public override string Option(Pieces[,] Board, int x, int y)
        {
            string can_move = "";

            if (!this.GetColor() & x < 9)
            {
                can_move += addCanMove(x + 1, y, Board);
                //if (Board[x + 1, y] == null|| Board[x + 1, y].GetColor())
                //{
                //    can_move += $"{x + 1},{y}";
                //}
            }
            if (this.GetColor() & x > 0)
            {
                can_move += addCanMove(x - 1, y, Board);
                //if (Board[x - 1, y] == null|| Board[x - 1, y].GetColor())
                //{
                //    can_move += $"{x - 1},{y}";
                //}
            }
            if ((this.GetColor() & x < 5) | ((!this.GetColor()) & x > 4))
            {
                if (y != 0)
                {
                    can_move += addCanMove(x, y - 1, Board);
                    //if (Board[x, y - 1] == null||Board[x, y - 1].GetColor() != this.GetColor())
                    //{
                    //    can_move += $"{x},{y - 1}";
                    //}
                }
                if (y != 8)
                {
                    can_move += addCanMove(x, y + 1, Board);
                    //if (Board[x, y + 1] == null|| Board[x, y + 1].GetColor() != this.GetColor())
                    //{
                    //    can_move += $"{x},{y + 1}";
                    //}
                }
            }
            return can_move;
        }
    }

    public class Pao : Pieces
    {
        public Pao(bool color)
            : base(color, "炮") { }

        //public object[] columnOption(Pieces[,] Board, int x, int y, int i)
        //{
        //    string can_move = "";
        //    int flag = 0;
        //    if (Board[x - i, y] != null)
        //    {
        //        if (flag == 1)
        //        {
        //            if (Board[x - i, y].GetColor() != this.GetColor())
        //            {
        //                can_move = can_move + $"{x - i},{y}";

        //            }
        //        }
        //        flag++;
        //    }
        //    if (flag == 0)
        //    {
        //        can_move = can_move + $"{x - i},{y}";
        //    }
        //    object[] obj = new object[2];
        //    obj[0] = can_move;
        //    obj[1] = flag;
        //    return obj;
        //}

        public override string Option(Pieces[,] Board, int x, int y)
        {
            string can_move = "";
            bool flag = true;

            for (int i = 1; i <= x; i++)    //up
            {
                if (Board[x - i, y] != null)
                {
                    if (!flag)
                    {
                        if (Board[x - i, y].GetColor() != this.GetColor())
                        {
                            can_move = can_move + $"{x - i},{y}";
                        }
                        break;
                    }
                    flag = false;
                }
                if (flag)
                {
                    can_move = can_move + $"{x - i},{y}";
                }
            }

            flag = true;
            for (int i = 1; i <= 9 - x; i++)  //down
            {

                if (Board[x + i, y] != null)
                {
                    if (!flag)
                    {
                        if (Board[x + i, y].GetColor() != this.GetColor())
                        {
                            can_move = can_move + $"{x + i},{y}";
                        }
                        break;
                    }
                    flag = false;
                }
                if (flag)
                {
                    can_move = can_move + $"{x + i},{y}";
                }
            }

            flag = true;
            for (int i = 1; i <= y; i++)  //left
            {

                if (Board[x, y - i] != null)
                {
                    if (!flag)
                    {
                        if (Board[x, y - i].GetColor() != this.GetColor())
                        {
                            can_move = can_move + $"{x},{y - i}";
                        }
                        break;
                    }
                    flag = false;
                }
                if (flag)
                {
                    can_move = can_move + $"{x},{y - i}";
                }
            }

            flag = true;
            for (int i = 1; i <= 8 - y; i++)   //right
            {

                if (Board[x, y + i] != null)
                {
                    if (!flag)
                    {
                        if (Board[x, y + i].GetColor() != this.GetColor())
                        {
                            can_move = can_move + $"{x},{y + i}";
                        }
                        break;
                    }
                    flag = false;
                }
                if (flag)
                {
                    can_move = can_move + $"{x},{y + i}";
                }
            }
            return can_move;
        }
    }

    public class Che : Pieces
    {
        public Che(bool color)
            : base(color, "车") { }

        public override string Option(Pieces[,] Board, int x, int y)
        {
            string can_move = "";
            for (int i = 1; i <= x; i++)
            {
                if (Board[x - i, y] == null)
                {
                    can_move = can_move + $"{x - i},{y}";
                }
                else
                {
                    if (Board[x - i, y].GetColor() != this.GetColor())
                    {
                        can_move = can_move + $"{x - i},{y}";
                    }
                    break;
                }
            }
            for (int i = 1; i <= 9 - x; i++)
            {
                if (Board[x + i, y] == null)
                {
                    can_move = can_move + $"{x + i},{y}";
                }
                else
                {
                    if (Board[x + i, y].GetColor() != this.GetColor())
                    {
                        can_move = can_move + $"{x + i},{y}";
                    }
                    break;
                }

            }
            for (int i = 1; i <= y; i++)
            {
                if (Board[x, y - i] == null)
                {
                    can_move = can_move + $"{x},{y - i}";
                }
                else
                {
                    if (Board[x, y - i].GetColor() != this.GetColor())
                    {
                        can_move = can_move + $"{x},{y - i}";
                    }
                    break;
                }
            }
            for (int i = 1; i <= 8 - y; i++)
            {
                if (Board[x, y + i] == null)
                {
                    can_move = can_move + $"{x},{y + i}";
                }
                else
                {
                    if (Board[x, y + i].GetColor() != this.GetColor())
                    {
                        can_move = can_move + $"{x},{y + i}";
                    }
                    break;
                }
            }

            return can_move;
        }


    }

    public class Ma : Pieces
    {
        public Ma(bool color)
            : base(color, "马") { }

        public override string Option(Pieces[,] Board, int x, int y)
        {
            string can_move = "";

            if (x >= 2)
            {
                if (Board[x - 1, y] == null)
                {
                    if (y < 8)
                    {
                        can_move += addCanMove(x - 2, y + 1, Board);
                        //if (Board[x - 2, y + 1] == null || Board[x - 2, y + 1].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 2},{y + 1}";
                        //}
                    }
                    if (y > 0)
                    {
                        can_move += addCanMove(x - 2, y - 1, Board);
                        //if (Board[x - 2, y - 1] == null || Board[x - 2, y - 1].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 2},{y - 1}";
                        //}
                    }
                }
            }
            if (x <= 7)
            {
                if (Board[x + 1, y] == null)
                {
                    if (y < 8)
                    {
                        can_move += addCanMove(x + 2, y + 1, Board);
                        //if (Board[x + 2, y + 1] == null || Board[x + 2, y + 1].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 2},{y + 1}";
                        //}
                    }
                    if (y > 0)
                    {
                        can_move += addCanMove(x + 2, y - 1, Board);
                        //if (Board[x + 2, y - 1] == null || Board[x + 2, y - 1].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 2},{y - 1}";
                        //}
                    }
                }
            }
            if (y >= 2)
            {
                if (Board[x, y - 1] == null)
                {
                    if (x < 9)
                    {
                        can_move += addCanMove(x + 1, y - 2, Board);
                        //if (Board[x + 1, y - 2] == null || Board[x + 1, y - 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 1},{y - 2}";
                        //}
                    }
                    if (x > 0)
                    {
                        can_move += addCanMove(x - 1, y - 2, Board);
                        //if (Board[x - 1, y - 2] == null || Board[x - 1, y - 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 1},{y - 2}";
                        //}
                    }
                }
            }
            if (y <= 6)
            {
                if (Board[x, y + 1] == null)
                {
                    if (x < 9)
                    {
                        can_move += addCanMove(x + 1, y + 2, Board);
                        //if (Board[x + 1, y + 2] == null || Board[x + 1, y + 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 1},{y + 2}";
                        //}
                    }
                    if (x > 0)
                    {
                        can_move += addCanMove(x - 1, y + 2, Board);
                        //if (Board[x - 1, y + 2] == null || Board[x - 1, y + 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 1},{y + 2}";
                        //}
                    }
                }
            }
            return can_move;
        }
    }

    public class Xiang : Pieces
    {
        public Xiang(bool color)
            : base(color, "象") { }

        public override string Option(Pieces[,] Board, int x, int y)
        {
            //int[] a = { +1, -1 };
            string can_move = "";

            if (x != 4 & x != 9)
            {
                if (y != 0)
                {
                    if (Board[x + 1, y - 1] == null)
                    {
                        can_move += addCanMove(x + 2, y - 2, Board);
                        //if (Board[x + 2, y - 2] == null || Board[x + 2, y - 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 2},{y - 2}";
                        //}
                    }
                }
                if (y != 8)
                {
                    if (Board[x + 1, y + 1] == null)
                    {
                        can_move += addCanMove(x + 2, y + 2, Board);
                        //if (Board[x + 2, y + 2] == null || Board[x + 2, y + 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + 2},{y + 2}";
                        //}
                    }
                }
            }
            if (x != 0 & x != 5)
            {
                if (y != 0)
                {
                    if (Board[x - 1, y - 1] == null)
                    {
                        can_move += addCanMove(x - 2, y - 2, Board);
                        //if (Board[x - 2, y - 2] == null || Board[x - 2, y - 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 2},{y - 2}";
                        //}
                    }
                }
                if (y != 8)
                {
                    if (Board[x - 1, y + 1] == null)
                    {
                        can_move += addCanMove(x - 2, y + 2, Board);
                        //if (Board[x - 2, y + 2] == null || Board[x - 2, y + 2].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x - 2},{y + 2}";
                        //}
                    }
                }
            }
            return can_move;
            //if (x == 4 | x == 9)
            //{
            //    foreach (int i in a)
            //    {
            //        if (Board[x + 1, y + i * 1] == null)
            //        {
            //            if(Board[x + 2, y + i * 2] == null | (Board[x + 2, y + i * 2].GetColor() != this.GetColor()))
            //            {
            //                can_move = can_move + $"[{x + 2},{y + i * 2}]";
            //            }
            //        }
            //    }
            //}
        }
    }

    public class Shi : Pieces
    {
        public Shi(bool color)
            : base(color, "仕") { }

        public override string Option(Pieces[,] Board, int x, int y)
        {
            int[] a = { 1, -1 };
            string can_move = "";
            if (x == 8 | x == 1)
            {
                foreach (int i in a)
                {
                    foreach (int j in a)
                    {
                        can_move += addCanMove(x + i, y + i, Board);
                        //if (Board[x + i, y + i] == null || Board[x + i, y + i].GetColor() != this.GetColor())
                        //{
                        //    can_move = can_move + $"{x + i},{y + i}";
                        //}
                    }
                }
            }
            else
            {
                if (this.GetColor())
                {
                    can_move += addCanMove(8, 4, Board);
                    //if (Board[8, 4] == null || !Board[8, 4].GetColor())
                    //{
                    //    can_move = can_move + $"8,4";
                    //}
                }
                if (!this.GetColor())
                {
                    can_move += addCanMove(1, 4, Board);
                    //if (Board[1, 4] == null || Board[1, 4].GetColor())
                    //{
                    //    can_move = can_move + $"1,4";
                    //}
                }
            }
            return can_move;
        }
    }

    public class Jiang : Pieces
    {
        public Jiang(bool color)
            : base(color, "将") { }
        public override string Option(Pieces[,] Board, int x, int y)
        {
            string can_move = "";
            if (y != 3)
            {
                can_move += addCanMove(x, y - 1, Board);
                //if (Board[x, y - 1] == null|| Board[x, y - 1].GetColor() != this.GetColor())
                //{
                //    can_move += $"{x},{y - 1}";
                //}
            }
            if (y != 5)
            {
                can_move += addCanMove(x, y + 1, Board);
                //if (Board[x, y + 1] == null||Board[x, y + 1].GetColor() != this.GetColor())
                //{
                //    can_move += $"{x},{y + 1}";
                //}
            }
            if (x != 2 & x != 9)
            {
                can_move += addCanMove(x + 1, y, Board);
                //if (Board[x + 1, y] == null|| Board[x + 1, y].GetColor() != this.GetColor())
                //{
                //    can_move += $"{x + 1},{y}";
                //}
            }
            if (x != 0 & x != 7)
            {
                can_move += addCanMove(x - 1, y, Board);
                //if (Board[x - 1, y] == null|| Board[x - 1, y].GetColor() != this.GetColor())
                //{
                //    can_move += $"{x - 1},{y}";
                //}
            }

            if (this.GetColor())    //jiang in the same colume.
            {
                for(int i = x-1; i > 0; i--)
                {
                    if (Board[i, y] != null)
                    {
                        if (Board[i, y].GetName() == "将")
                        {
                            can_move += $"{i},{y}";
                        }
                        else break;
                    }
                }
            }
            else
            {
                for (int i = x; i < 9; i++)
                {
                    if (Board[i, y] != null)
                    {
                        if (Board[i, y].GetName() == "将")
                        {
                            can_move += $"{i},{y}";
                        }
                        else break;
                    }
                }
            }
            return can_move;
        }
    }


    public abstract class Pieces
    {

        private bool color;  //black is true,red is false
        private string name;
        public Pieces(bool color, string name)
        {
            this.color = color;
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
        public bool GetColor()
        {
            return this.color;
        }
        public void Display()
        {
            if (!this.color)
            {
                Console.ForegroundColor = ConsoleColor.Red;

            }
            if (this.color)
            {
                Console.ForegroundColor = ConsoleColor.Black;

            }
            Console.Write(this.name);
        }

        public abstract string Option(Pieces[,] Board, int x, int y);

        public string addCanMove(int x,int y,Pieces[,] board)
        {
            if (board[x, y] == null || board[x, y].GetColor() != this.GetColor())
            {
                return $"{x},{y}";
            }
            else return "";
        }
    }
}
