string name;
char symbol;
int nameLenght;
Console.WriteLine("Введите имя:");
name = Console.ReadLine();
nameLenght = name.Length;
Console.Write("Введите символ: ");
symbol = Convert.ToChar(Console.ReadLine());
Console.WriteLine("\n");

for (int i = 0; i < nameLenght + 2; i++)
{
    Console.Write(symbol);
}

Console.WriteLine($"\n{symbol} {name} {symbol}");

for (int i = 0; i < nameLenght + 2; i++)
{
    Console.Write(symbol);
}
Console.ReadKey();