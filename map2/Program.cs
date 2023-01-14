using System.ComponentModel;

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
int mapHeight = CalculateMapHeight(mapOne);
int directionX = 0;
int directionY = 0;
string endGameMessage = string.Empty;

char[,] map = ReadMap(mapOne, out positionX, out positionY);

DrawMap(map);

while (isPlaying)
{
    Console.SetCursorPosition(positionX, positionY);
    Console.Write('@');
    GetDirection(ref directionX, ref directionY);
    OutputResult(ref positionX, ref positionY, ref map, endGameMessage, isPlaying, directionX, directionY);
    WinGame(map, positionY, positionX, ref isPlaying, endGameMessage);
    LoseGame(map, positionY, positionX, ref isPlaying, endGameMessage);
}

static void GetDirection(ref int directionX, ref int directionY)
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

static void OutputResult(ref int positionX, ref int positionY, ref char[,] map, string endGameMessage, bool isPlaying, int directionX, int directionY)
{
    string mapOne = "map.txt";
    int mapHeight = CalculateMapHeight(mapOne);
    int temporaryPositionX = positionX + directionX;
    int temporaryPositionY = positionY + directionY;

    if (temporaryPositionX < 0 || temporaryPositionX > map.GetLength(1))
    {
        return;
    }

    if (temporaryPositionY < 0 || temporaryPositionY > map.GetLength(0))
    {
        return;
    }

    if (map[temporaryPositionY, temporaryPositionX] != '#')
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(" ");

        positionX = temporaryPositionX;
        positionY = temporaryPositionY;

        Console.SetCursorPosition(positionX, positionY);
        Console.Write('@');
    }
}

static void WinGame(char[,] map, int positionY, int positionX, ref bool isPlaying, string endGameMessage)
{
    if (map[positionY, positionX] == '$')
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write("Y");
        endGameMessage = "Вы прошли игру!";
        isPlaying = false;
    }
    Console.SetCursorPosition(2, 15);
    Console.WriteLine(endGameMessage);
}

static void LoseGame(char[,] map, int positionY, int positionX, ref bool isPlaying, string endGameMessage)
{
    if (map[positionY, positionX] == 'X')
    {
        Console.SetCursorPosition(positionX, positionY);
        Console.Write("+");
        endGameMessage = "Вы проиграли!";
        isPlaying = false;
    }
    Console.SetCursorPosition(2, 15);
    Console.WriteLine(endGameMessage);
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
                positionX = j;
                positionY = i;
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