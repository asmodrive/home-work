﻿string password = "doka2";
string userInput;
int tryCount = 3;

for (int i = 0; i < tryCount; i++)
{
    Console.WriteLine("Введите пароль:");
    userInput = Console.ReadLine();
    if (userInput == password)
    {
        Console.WriteLine("Вы удачно ввели пароль, можете запустить доку2.");
        break;
    }
    else
    {
        Console.WriteLine($"Неверный пароль, попробуйте еще раз, у вас осталось {tryCount - i - 1} попыток.");
    }
}