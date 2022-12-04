using System.Diagnostics.Metrics;

int minValue = 3;
int maxValue = 7;
int arraySize = 30;
int maxCount = 0;
int counter = 1;
string lineOfNumbers = "";
int[] numbers = new int[arraySize];
Random random = new Random();

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minValue, maxValue);
    Console.Write($"{numbers[i]} ");
}

Console.WriteLine();

for (int i = 0; i < numbers.Length - 1; i++)
{
    if (numbers[i] == numbers[i + 1])
    {
        counter++;

        if (counter == maxCount)
        {
            lineOfNumbers += $"{numbers[i]} ";
        }

        if (counter > maxCount)
        {
            maxCount = counter;
            lineOfNumbers = "";
            lineOfNumbers = $"{numbers[i]} ";
        }
    }
    else
    {
        counter = 1;
    }
}

Console.WriteLine($"\nЧисла {lineOfNumbers} встречаются {maxCount} раз(а).");
