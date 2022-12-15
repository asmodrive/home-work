static void Shuffle(int[] numbers)
{
    Random rand = new Random();

    for (int i = numbers.Length - 1; i >= 1; i--)
    {
        int j = rand.Next(i + 1);

        int tmp = numbers[j];
        numbers[j] = numbers[i];
        numbers[i] = tmp;
        Console.WriteLine(tmp);
    }
}