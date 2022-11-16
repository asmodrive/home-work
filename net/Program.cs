int firstNaturalNumber = 100;
int lastNaturalNumber = 999;
int minNumber = 1;
int maxNumber = 27;
int counterMultipleNumbers = 0;

Random random = new Random();
int randomNumber = random.Next(minNumber, maxNumber);

for (int currentNumber = 0; currentNumber < lastNaturalNumber; currentNumber += randomNumber)
{

    if (currentNumber >= firstNaturalNumber)
    {
        counterMultipleNumbers++;
    }
}

Console.WriteLine($"Количество трехзначных натуральных чисел, кратных {randomNumber},будет:{counterMultipleNumbers}");
Console.ReadLine();