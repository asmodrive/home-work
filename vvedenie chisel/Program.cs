using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

const string Exit = "Выход";
const string Amount = "Сумма";

Console.WriteLine($"Добрый день, введите команду  для их дальнейших действий: \n{Amount} - суммирование ваших чисел;\n{Exit} - выход из программы.");
string userInput = string.Empty;
int sumNumbers = 0;
int[] numbers = new int[0];


while (userInput != Exit)
{
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case Amount:
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    sumNumbers += numbers[i];
                }

                Console.WriteLine($"Сумма строки равна - {sumNumbers}");

            }
            break;

        case Exit:
            {
                Console.WriteLine("Вы вышли из программы.");
            }
            break;

        default:
            {
                if (int.TryParse(userInput, out int value))
                {
                    Console.WriteLine($"{value} - это число");

                    int[] tempNumbers = new int[numbers.Length+1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length-1] = value;
                    numbers = tempNumbers;
                }
                else
                {
                    Console.WriteLine("Это не число.");
                }
            }
            break;
            
    }
}


