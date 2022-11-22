int symbol = 0;
int result = 1;
int count = 0;
Console.WriteLine("Введите '(' и ')'.");
string text = Console.ReadLine();
for (int i = 0; i < text.Length; i++)
{
    if (text[i] == '(')
    {
        symbol++;
    }
    else if (text[i] == ')')
    {
        count++;
        symbol--;
    }

    if (symbol < 0)
    {
        break;
    } 

    if (symbol == 0)
    {
        result = count;
    }
}
if (symbol == 0)
    {
        Console.WriteLine($"Строка корректная {text} \nМаксимум глубина равняется: {result}");
    }
else
{
    Console.WriteLine($"Ошибка! Не верная строка {text}");
}
