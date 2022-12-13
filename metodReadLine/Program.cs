using System.Transactions;

Console.WriteLine($"Вы ввели: {Enter()}");

static int Enter()
{
    bool isRunning = false;
    int value = 0;

    while (isRunning == false)
    {
        Console.WriteLine("Введите число:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out value) == true)
        {
            Console.WriteLine($"{value} - это число");
            isRunning = true;
        }
        else
        {
            Console.WriteLine($"{userInput} - это не число.");
        }
    }
    return value;
}