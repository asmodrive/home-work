using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player('@', 5, 5);
            Renderr renderr = new Renderr();
            Renderr.ShowInfo(player.SymbolPlayer, );
        }
    }

    class Player
    {
        public char SymbolPlayer;
        private int PositionX;
        private int PositionY;

        public Player (char symbolPlayer, int positionX, int positionY)
        {
            SymbolPlayer = symbolPlayer;
            PositionX = positionX;
            PositionY = positionY;
        }
    }

    class Renderr
    {
        public void ShowInfo (char symbolPlayer, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX , positionY);
            Console.Write(symbolPlayer);
        }
    }


}
