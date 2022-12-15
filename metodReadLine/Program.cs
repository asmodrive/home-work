using System.Transactions;

Console.WriteLine($"Вы ввели: {ReadInt()}");

static int ReadInt()
{
    bool isRunning = true;
    int value = 0;

    while (isRunning)
    {
        Console.WriteLine("Введите число:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out value))
        {
            Console.WriteLine($"{value} - это число");
            isRunning = false;
        }
        else
        {
            Console.WriteLine($"{userInput} - это не число.");
        }
    }

    return value;
}