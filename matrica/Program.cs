using System;
int minValue = 0;
int maxValue = 30;
int rowCount = 10;
int columnCount = 10;
int maxNumber = minValue;
int targetValue = 0;
int[,] numbers = new int[rowCount, columnCount];
Random random = new Random();

for(int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        int temporaryNumber = random.Next(minValue, maxValue);
        numbers[i, j] = temporaryNumber;

        if (maxNumber < temporaryNumber)
            maxNumber = temporaryNumber;

        Console.Write($"{numbers[i, j]} ");
    }

    Console.WriteLine();
}

Console.WriteLine($"\n{maxNumber} - максимальное число\n");

for (int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        if (numbers[i, j] == maxNumber)
        {
            numbers[i, j] = targetValue;
        }

        Console.Write($"{numbers[i, j]} ");
    }

    Console.WriteLine();
}
