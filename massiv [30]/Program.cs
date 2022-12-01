int[] numbers = new int[30];
int minNumber = 0;
int maxNumber = 30;
Random random = new Random();
int maxValue = numbers[0];

for (int i = 1; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minNumber, maxNumber);

    if (numbers[i] > maxValue)
    {
        maxValue = numbers[i];
    }
}
Console.WriteLine(maxValue);