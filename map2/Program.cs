using System.ComponentModel;
using System.Numerics;
using System.Threading;

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
int positionX;
int positionY;
int directionX = 0;
int directionY = 0;
string endGameMessage = string.Empty;
char[,] map = ReadMap(mapOne, out positionX, out positionY);

DrawMap(map);

while (isPlaying)
{
    MovePlayer(map, positionY, positionX, ref directionX, ref directionY);
    CheckPlayer(ref positionX, ref positionY, ref map, directionX, directionY);
    isPlaying = CheckWin(map, positionY, positionX, endGameMessage);
    isPlaying = CheckLose(map, positionY, positionX, endGameMessage);
}

static void MovePlayer(char[,] map, int positionY, int positionX, ref int directionX, ref int directionY)
{
    CheckBarrier(map, positionY, positionX, directionX, directionY);
    ConsoleKeyInfo key = Console.ReadKey(true);
    directionY = 0;
    directionX = 0;

    switch (key.Key)
    {
        case AlternativeMoveUpCommand:
        case MoveUpCommand:
            directionY = -1;
            break;
        case AlternativeMoveDownCommand:
        case MoveDownCommand:
            directionY = 1;
            break;
        case AlternativeMoveLeftCommand:
        case MoveLeftCommand:
            directionX = -1;
            break;
        case AlternativeMoveRightCommand:
        case MoveRightCommand:
            directionX = 1;
            break;
    }
}

static void CheckPlayer(ref int positionX, ref int positionY, ref char[,] map, int directionX, int directionY)
{
    int temporaryPositionX = positionX + directionX;
    int temporaryPositionY = positionY + directionY;
    char player = '@';
    char barrier = '#';

    if (temporaryPositionX < 0 || temporaryPositionX > map.GetLength(1) - 1)
    {
        return;
    }

    if (temporaryPositionY < 0 || temporaryPositionY > map.GetLength(0) - 1)
    {
        return;
    }

    if (map[temporaryPositionY, temporaryPositionX] != barrier)
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(" ");

        positionX = temporaryPositionX;
        positionY = temporaryPositionY;

    }

    Console.SetCursorPosition(positionX, positionY);
    Console.Write(player);
}

static bool CheckBarrier(char[,] map, int positionY, int positionX, int directionX, int directionY)
{
    int temporaryPositionX = positionX + directionX;
    int temporaryPositionY = positionY + directionY;
    char player = '@';
    char barrier = '#';
    bool isPlaying = true;

    if (map[temporaryPositionY, temporaryPositionX] != barrier)
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(" ");

        positionX = temporaryPositionX;
        positionY = temporaryPositionY;

    }

    Console.SetCursorPosition(positionX, positionY);
    Console.Write(player);

    return isPlaying;
}

static bool CheckLose(char[,] map, int positionY, int positionX, string endGameMessage)
{
    bool isPlaying = true;
    int horizontalPosition = 0;
    int verticalPosition = 15;
    char symbolExpression = 'X';
    char playerDied = '+';

    if (map[positionY, positionX] == symbolExpression)
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(playerDied);
        endGameMessage = "Вы проиграли!";
        isPlaying = false;
    }

    Console.SetCursorPosition(horizontalPosition, verticalPosition);
    Console.WriteLine(endGameMessage);

    return isPlaying;
}

static bool CheckWin(char[,] map, int positionY, int positionX, string endGameMessage)
{
    bool isPlaying = true;
    int horizontalPosition = 0;
    int verticalPosition = 15;
    char playerWon = 'Y';
    char symbolVictory = '$';

    if (map[positionY, positionX] == symbolVictory)
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(playerWon);
        endGameMessage = "Вы прошли игру!";
        isPlaying = false;
    }

    Console.SetCursorPosition(horizontalPosition, verticalPosition);
    Console.WriteLine(endGameMessage);

    return isPlaying;
}

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

static char[,] ReadMap(string mapName, out int positionPlayerX, out int positionPlayerY)
{
    positionPlayerX = 0;
    positionPlayerY = 0;
    char symbol = '@';
    string mapsPath = "Maps/";
    string[] newFile = File.ReadAllLines(Path.Combine(mapsPath, mapName));
    char[,] map = new char[newFile.Length, newFile[0].Length];

    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            map[i, j] = newFile[i][j];

            if (map[i, j] == symbol)
            {
                positionPlayerX = j;
                positionPlayerY = i;
            }
        }
    }

    return map;
}