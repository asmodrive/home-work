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
bool isWin = true;
bool isLose = true;
Console.CursorVisible = false;
string mapOne = "map.txt";
int positionX;
int positionY;
int directionX = 0;
int directionY = 0;
int horizontalPosition = 0;
int verticalPosition = 16;
string endGameMessage = string.Empty;
char[,] map = ReadMap(mapOne, out positionX, out positionY);

DrawMap(map);

while (isPlaying)
{
    GetPlayerDirection(map, positionY, positionX, ref directionX, ref directionY);
    MovePlayer(ref positionX, ref positionY, ref map, directionX, directionY);
    isWin = CheckWin(map, positionY, positionX);
    isLose = CheckLose(map, positionY, positionX, endGameMessage);

    if (isWin == true || isLose == true)
    {
        isPlaying = false;
    }
}

if (isWin)
{
    DrawText("Вы победили", verticalPosition, horizontalPosition);
}
else if (isLose)
{
    DrawText("Вы проиграли", verticalPosition, horizontalPosition);
}

static void GetPlayerDirection(char[,] map, int positionY, int positionX, ref int directionX, ref int directionY)
{
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

static void MovePlayer(ref int positionX, ref int positionY, ref char[,] map, int directionX, int directionY)
{
    string clearSymbol = " ";
    string symbolPlayer = "@";
    int temporaryPositionX = positionX + directionX;
    int temporaryPositionY = positionY + directionY;

    if (temporaryPositionX < 0 || temporaryPositionX > map.GetLength(1) - 1)
    {
        return;
    }

    if (temporaryPositionY < 0 || temporaryPositionY > map.GetLength(0) - 1)
    {
        return;
    }

    if (CheckBarrier(map, positionY, positionX, directionX, directionY))
    {
        return;
    }

    DrawText(clearSymbol, positionY, positionX);

    positionX = temporaryPositionX;
    positionY = temporaryPositionY;

    DrawText(symbolPlayer, positionY, positionX);
}

static bool CheckBarrier(char[,] map, int positionY, int positionX, int directionX, int directionY)
{
    int temporaryPositionX = positionX + directionX;
    int temporaryPositionY = positionY + directionY;
    char barrier = '#';

    if (map[temporaryPositionY, temporaryPositionX] == barrier)
    {
        return true;
    }

    return false;
}

static bool CheckLose(char[,] map, int positionY, int positionX, string endGameMessage)
{
    char symbolExpression = 'X';

    if (map[positionY, positionX] == symbolExpression)
    {
        return true;
    }

    return false;
}

static bool CheckWin(char[,] map, int positionY, int positionX)
{
    char symbolVictory = '$';

    if (map[positionY, positionX] == symbolVictory)
    {
        return true;
    }

    return false;
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

static void DrawText(string text, int positionY, int positionX)
{
    Console.SetCursorPosition(positionX, positionY);
    Console.Write(text);
}

