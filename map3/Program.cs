using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace map3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            int pacmanX = 1;
            int pacmanY = 1;
            char[,] map = ReadMap("map.txt");
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            while (isWorking)
            {
                DrawMap(map);

                Console.SetCursorPosition(pacmanX, pacmanY);
                Console.Write("@");

                Console.SetCursorPosition(62, 0);
                Console.Write(pressedKey.KeyChar);

                pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref pacmanX, ref pacmanY, map);
            }
        }

        static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines("map.txt");

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void HandleInput (ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY, char[,] map)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = pacmanX + direction[0];
            int nextPacmanPositionY = pacmanY + direction[1];

            if (map[nextPacmanPositionX, nextPacmanPositionY] == ' ')
            {
                pacmanX = nextPacmanPositionX;
                pacmanY = nextPacmanPositionY;
            }
        }

        static int[] GetDirection (ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
                direction[1] -= 1;
            else if (pressedKey.Key == ConsoleKey.DownArrow)
                direction[1] += 1;
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
                direction[0] -= 1;
            else if (pressedKey.Key == ConsoleKey.RightArrow)
                direction[0] += 1;

            return direction;
        }

        static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }
    }
}
