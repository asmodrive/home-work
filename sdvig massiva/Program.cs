int arraySize = 5;
int minValue = 0;
int maxValue = 10;
int[] numbers = new int[arraySize];
Random random = new Random(123123);

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minValue, maxValue);
    Console.Write($"{numbers[i]} ");
}
