string name;
char symbol;
int nameLenght;
Console.WriteLine("Введите имя:");
name = Console.ReadLine();
nameLenght = name.Length;
Console.Write("Введите символ: ");
symbol = Convert.ToChar(Console.ReadLine());
Console.WriteLine("\n");

for (int i = 1; i < nameLenght + 5; i++)
{
    Console.Write(symbol);
}

Console.WriteLine($"\n{symbol} {name} {symbol}");

