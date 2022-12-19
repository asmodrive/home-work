using System;
int arraySize = 10;
int[] numbers = new int[arraySize];
int minValue = 0;
int maxValue = 5;
Random random = new Random(123412);

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minValue, maxValue);
}

PrintNumbers(numbers);
Console.WriteLine();
Shuffle(numbers);
Console.WriteLine();
PrintNumbers(numbers);

static void Shuffle(int[] numbers)
{
    Random random = new Random(123412);

    for (int i = numbers.Length-1; i >= 1; i--)
    {
        int temporaryIndex = random.Next(i + 1);
        int temporaryNumber = numbers[temporaryIndex];
        numbers[temporaryIndex] = numbers[i];
        numbers[i] = temporaryNumber;
    }
}

static void PrintNumbers(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.Write($"{numbers[i]} ");
    }
}