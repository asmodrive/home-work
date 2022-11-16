Random random = new Random();
int firstNumber = 1;
int secondNumber = 28;
int randomNumber = random.Next(firstNumber, secondNumber);
int numbers = 0;
int largerNumber = 1000;
int smallerNumber = 100;

for (int currentNumber = 0; currentNumber < largerNumber; currentNumber += randomNumber)
{
    if (currentNumber >= smallerNumber)
    {
        numbers++;
    }
}
Console.WriteLine($"Количество трехзначных натуральных чисел, кратных {randomNumber},будет:{numbers}");