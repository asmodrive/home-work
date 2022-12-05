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

Console.WriteLine("Введите насколько символов вы хотите передвинуть массив влево:");
string userInput = Console.ReadLine();

if (uint.TryParse(userInput, out uint value))
{
    for (uint j = 0; j < value; j++)
    {
        int boxHolodilnik = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i < numbers.Length - 1)
            {
                numbers[i] = numbers[i + 1];
            }
            else
            {
                numbers[i] = boxHolodilnik;
            }
        }
    }
}
else
{
    Console.WriteLine("Это не число.");
}

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"{numbers[i]} ");
}    
