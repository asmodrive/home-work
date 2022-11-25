int symbol = 0;
int count = 0;
Console.WriteLine("Введите '(' и ')'.");
string text = Console.ReadLine();

for (int i = 0; i < text.Length; i++)
{
    if (text[i] == '(')
    {
        symbol++;
        if (symbol == count)
        count++;
    }
    else if (text[i] == ')')
    {
        symbol--;
    }
    
    if (symbol < 0)
    {
        break;
    } 
}

if (symbol == 0)
    {
        Console.WriteLine($"Строка корректная {text} \nМаксимум глубина равняется: {count}");
    }
else
{
    Console.WriteLine($"Ошибка! Не верная строка {text}");
}