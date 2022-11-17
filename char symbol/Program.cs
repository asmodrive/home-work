string name;
char symbol;
int nameLenght;
Console.WriteLine("Введите имя:");
name = Console.ReadLine();
nameLenght = name.Length;
Console.Write("Введите символ: ");
symbol = Convert.ToChar(Console.ReadLine());
Console.WriteLine("\n");

for (int initialNumber = 1; initialNumber < nameLenght + 5; initialNumber++)
{
    Console.Write(symbol);
}

Console.WriteLine($"\n{symbol} {name} {symbol}");
for (int initialNumber = 0; initialNumber < nameLenght + 5; initialNumber++)
{
    Console.Write(symbol);
}
