Random rand = new Random();
int randomNumber = rand.Next(1, 28);
int numbers = 0;

for (int currentNumber = 0; currentNumber < 1000; currentNumber += randomNumber)
{
    if (currentNumber >= 100)
    {
        numbers++;
    }
}
Console.WriteLine($"Количество трехзначных натуральных чисел, кратных {randomNumber},будет:{numbers}");