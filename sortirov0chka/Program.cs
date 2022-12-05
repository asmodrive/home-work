using System.Globalization;

int arraySize = 10;
int minValue = 0;
int maxValue = 10;
int[] numbers = new int[arraySize];
Random random = new Random(123123);

Console.WriteLine("Исходный массив:");

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minValue, maxValue);
    Console.Write($"{numbers[i]} ");
}

for (int i = 0; i < numbers.Length; i++)
{
    for (int j = 0; j < numbers.Length - 1; j++)
    {
        if (numbers[j] > numbers[j + 1])
        {
            int temp = numbers[j];
            numbers[j] = numbers[j + 1];
            numbers[j + 1] = temp;
        }
    }
}

Console.WriteLine("\nОтсортированный массив:");

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"{numbers[i]} ");
}