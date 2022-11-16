<<<<<<< HEAD
﻿int firstNaturalNumber = 100;
int lastNaturalNumber = 999;
int minNumber = 1;
int maxNumber = 27;
int counterMultipleNumbers = 0;

Random random = new Random();
int randomNumber = random.Next(minNumber, maxNumber);

for (int currentNumber = 0; currentNumber < lastNaturalNumber; currentNumber += randomNumber)
{

    if (currentNumber >= firstNaturalNumber)
    {
        counterMultipleNumbers++;
    }
}

Console.WriteLine($"Количество трехзначных натуральных чисел, кратных {randomNumber},будет:{counterMultipleNumbers}");
Console.ReadLine();
=======
﻿Console.WriteLine("Введите ваш возраст:");
int age = Convert.ToInt32(Console.ReadLine());
int userInput;

if (age >= 18)
{
    Console.WriteLine("Выберите свое пиво:");
    Console.WriteLine("1 - Жигулевское, 50 рублей;");
    Console.WriteLine("2 - Бад безалкогольный, 45 рублей;");
    Console.WriteLine("3 - Яблочный сидр, 75 рублей");
    userInput = Convert.ToInt32(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            Console.WriteLine("Вы приобрели на последние гроши саки в бутылке, поздравялем!");
            break;
            case 2:
            Console.WriteLine("");
            break;
        case 3:
            Console.WriteLine("");
            break;
    }
}
else
{
    Console.WriteLine("");
}
>>>>>>> main
