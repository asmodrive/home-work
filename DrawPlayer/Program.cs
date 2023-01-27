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
            char hero = '@';
            int horizontalPosition = 25;
            int verticalPosition = 5;

            Player player = new Player(hero, horizontalPosition, verticalPosition);
            Renderr renderr = new Renderr();
            renderr.ShowInfo(player.SymbolPlayer, player.PositionX, player.PositionY);
            Console.ReadKey(true);
        }
    }

    class Player
    {
        public char SymbolPlayer { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

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
