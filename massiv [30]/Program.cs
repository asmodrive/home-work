int arrayLength = 30;
int[] numbers = new int[arrayLength];
int minNumber = 0;
int maxNumber = 30;
Random random = new Random();

Console.WriteLine("Исходный массив.");

for (int i = 1; i < numbers.Length; i++)
{
    numbers[i] = random.Next(minNumber, maxNumber);
    Console.Write($"{numbers[i]} ");
}

Console.WriteLine("\nЛокальные максимумы.");
if (numbers[0] > numbers[1] )
{
    Console.Write($"\n{ numbers[0]}");
}

for (int i = 1; i < numbers.Length-1; i++)
{
   if (numbers[i] > numbers[i-1] && numbers[i] > numbers[i+1])
    {
        Console.Write($"{numbers[i]} ");
    }
}

if (numbers[numbers.Length-1] > numbers[numbers.Length-2])
{
    Console.Write($"{numbers[numbers.Length-1]}");
}
