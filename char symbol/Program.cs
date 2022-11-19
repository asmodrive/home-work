string name;
char symbol;
int nameLenght;
Console.WriteLine("Введите имя:");
name = Console.ReadLine();
nameLenght = name.Length;
Console.Write("Введите символ: ");
symbol = Convert.ToChar(Console.Read());
string frame = "";
string secondLine = $"{symbol} {name} {symbol}";

for (int i = 1; i < secondLine.Length; i++)
{
    frame += symbol;
}

Console.WriteLine(frame);
Console.WriteLine(secondLine);
Console.WriteLine(frame);