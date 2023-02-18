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
            renderr.DrawPlayer(player.Hero, player.PositionX, player.PositionY);
            Console.ReadKey(true);
        }
    }

    class Player
    {
        public Player (char hero, int positionX, int positionY)
        {
            Hero = hero;
            PositionX = positionX;
            PositionY = positionY;
        }

        public char Hero { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
    }

    class Renderr
    {
        public void DrawPlayer (char symbolPlayer, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX , positionY);
            Console.Write(symbolPlayer);
        }
    }
}
