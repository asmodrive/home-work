using System.IO;

bool isPlaying = true;
Console.CursorVisible = false;
string mapOne = "map.txt";
int positionX;
int positionY;
int directionX = 0;
int directionY = 1;
int mapHeight = CalculateMapHeight(mapOne);
string endGameMessage = string.Empty;

char[,] map = ReadMap(mapOne, out positionX, out positionY);

DrawMap(map);

do
{
    Console.SetCursorPosition(positionY, positionX);
    Console.Write('@');

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case var consoleKey when consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.W:
                directionX = -1;
                directionY = 0;
                break;
            case var consoleKey when consoleKey == ConsoleKey.DownArrow || consoleKey == ConsoleKey.S:
                directionX = 1;
                directionY = 0;
                break;
            case var consoleKey when consoleKey == ConsoleKey.LeftArrow || consoleKey == ConsoleKey.A:
                directionX = 0;
                directionY = -1;
                break;
            case var consoleKey when consoleKey == ConsoleKey.RightArrow || consoleKey == ConsoleKey.D:
                directionX = 0;
                directionY = 1;
                break;
            default:
                directionY = 0;
                directionX = 0;
                break;
        }

        if (map[directionX + positionX, directionY + positionY] != '#')
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY, positionX);
            Console.Write('@');
        }

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
    }
}
while (isPlaying);

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

static int CalculateMapHeight (string mapName)
{
    string mapsPath = "Maps/";
    string[] newFile = File.ReadAllLines(Path.Combine(mapsPath, mapName));

    return newFile.Length;
}

