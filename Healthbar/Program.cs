using System.Numerics;

Console.WriteLine("Добрый день, введите сколько % предложенной строки вы хотит закрасить: ");
int healph = Convert.ToInt32(Console.ReadLine());
int maxHealph = 100;

DrawBar(healph, maxHealph, ConsoleColor.Red);

Console.WriteLine($"\nВы закрасили {healph} %.");


static void DrawBar (int value, int maxValue, ConsoleColor color)
{
    int barPositionX = 0;
    int barPositionY = 0;
    ConsoleColor defauleColor = Console.BackgroundColor;
    string bar = "";

    for (int i = 0; i < value; i++)
    {
        bar += ' ';
    }

    Console.SetCursorPosition(barPositionX, barPositionY);
    Console.Write('[');
    Console.BackgroundColor = color;
    Console.Write(bar);
    Console.BackgroundColor = defauleColor;

    bar = "";

    for (int i = value; i < maxValue; i++)
    {
        bar += ' ';
    }

    Console.Write($"{bar}]");
}