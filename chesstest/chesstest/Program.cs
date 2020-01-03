using System;

namespace chesstest.Properties
{
   
    class MainClass
    {
        public static void Main(string[] args)
        {

            Board ChessMaster = new Board();
            Console.WriteLine("welcome to ChineseChessMaster!\n C'est parti!");
            ChessMaster.Display("");
            // false-red true-black
            ChessMaster.game();
        }

        
    }
}
