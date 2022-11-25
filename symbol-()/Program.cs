int maxDepth = 0;
int finalDepth = 0;
char openBracket = '(';
char closeBracket = ')';
Console.WriteLine($"Введите {openBracket} и {closeBracket}.");
string text = Console.ReadLine();

for (int i = 0; i < text.Length; i++)
{
    if (text[i] == openBracket)
    {
        maxDepth++;

        if (maxDepth > finalDepth)
            finalDepth = maxDepth;
    }
    else if (text[i] == closeBracket)
    {
        maxDepth--;
    }
    
    if (maxDepth < 0)
    {
        break;
    } 
}

if (maxDepth == 0)
    {
        Console.WriteLine($"Строка корректная {text} \nМаксимум глубина равняется: {finalDepth}");
    }
else
    {
        Console.WriteLine($"Ошибка! Не верная строка {text}");
    }