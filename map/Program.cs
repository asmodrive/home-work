using System.IO;
using System.Linq.Expressions;

const ConsoleKey MoveUpCommand = ConsoleKey.UpArrow;
const ConsoleKey MoveDownCommand = ConsoleKey.DownArrow;
const ConsoleKey MoveLeftCommand = ConsoleKey.LeftArrow;
const ConsoleKey MoveRightCommand = ConsoleKey.RightArrow;
const ConsoleKey AlternativeMoveUpCommand = ConsoleKey.W;
const ConsoleKey AlternativeMoveDownCommand = ConsoleKey.S;
const ConsoleKey AlternativeMoveLeftCommand = ConsoleKey.A;
const ConsoleKey AlternativeMoveRightCommand = ConsoleKey.D;

bool isPlaying = true;
Console.CursorVisible = false;
string mapOne = "map.txt";
int positionX = 1;
int positionY = 1;
int directionX = 0;
int directionY = 1;
int mapHeight = CalculateMapHeight(mapOne);
string endGameMessage = string.Empty;


char[,] map = ReadMap(mapOne, out positionX, out positionY);
DrawMap(map);

while (isPlaying)
{
    MovementManager(ref positionY, ref positionX, directionY, directionX);
    PlayerWithdrawal(map, positionY, positionX, directionY, directionX);
    OutputResult(map, positionY, positionX, isPlaying, endGameMessage);
    Console.ReadKey(true);
}

static void MovementManager(ref int positionY, ref int positionX, int directionY, int directionX, char symbol = '@')
{
    symbol = '@';
    Console.SetCursorPosition(positionY, positionX);
    Console.Write(symbol);

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case AlternativeMoveUpCommand:
            case MoveUpCommand:
                directionX = -1;
                directionY = 0;
                break;
            case AlternativeMoveDownCommand:
            case MoveDownCommand:
                directionX = 1;
                directionY = 0;
                break;
            case AlternativeMoveLeftCommand:
            case MoveLeftCommand:
                directionX = 0;
                directionY = -1;
                break;
            case AlternativeMoveRightCommand:
            case MoveRightCommand:
                directionX = 0;
                directionY = 1;
                break;
            default:
                directionY = 0;
                directionX = 0;
                break;
        }
    }
}

static void PlayerWithdrawal (char[,] map, int positionY, int positionX, int directionY, int directionX)
{
    char symbol = '@';

    if (map[directionX + positionX, directionY + positionY] != '#')
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(" ");

        positionX += directionX;
        positionY += directionY;

        Console.SetCursorPosition(positionY, positionX);
        Console.Write(symbol);
    }
}

static bool OutputResult(char[,] map, int positionY, int positionX, bool isPlaying, string endGameMessage)
{

    if (map[positionX, positionY] == '$')
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write("Y");
        endGameMessage = "Вы прошли игру!";
        isPlaying = false;
    }


    if (map[positionX, positionY] == 'X')
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write("+");
        endGameMessage = "Вы проиграли!";
        isPlaying = false;
    }
    return isPlaying;
}

Console.SetCursorPosition(positionY = 0, mapHeight + 1);
Console.WriteLine(endGameMessage);

static void DrawMap(char[,] map)
{
    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            Console.Write(map[i, j]);
        }
        Console.WriteLine();
    }
}

static char[,] ReadMap(string mapName, out int positionX, out int positionY)
{
    positionX = 0;
    positionY = 0;
    string mapsPath = "Maps/";
    string[] newFile = File.ReadAllLines(Path.Combine(mapsPath, mapName));
    char[,] map = new char[newFile.Length, newFile[0].Length];

    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            map[i, j] = newFile[i][j];

            if (map[i, j] == '@')
            {
                positionX = i;
                positionY = j;
            }
        }
    }

    return map;
}

static int CalculateMapHeight(string mapName)
{
    string mapsPath = "Maps/";
    string[] newFile = File.ReadAllLines(Path.Combine(mapsPath, mapName));

    return newFile.Length;
}

