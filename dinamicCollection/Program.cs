using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinamicCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Exit = "Выход";
            const string Amount = "Сумма";

            Console.WriteLine($"Добрый день, введите команду  для их дальнейших действий: \n{Amount} - суммирование ваших чисел;\n{Exit} - выход из программы.");
            string userInput = string.Empty;
            List<string> array = new List<string>();
            int[] numbers = new int[0];
            bool isRunning = true;


            while (isRunning)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case Amount:
                        {
                            int sumNumbers = 0;

                            for (int i = 0; i < numbers.Length; i++)
                            {
                                sumNumbers += numbers[i];
                            }

                            Console.WriteLine($"Сумма строки равна - {sumNumbers}");

                        }
                        break;

                    case Exit:
                        {
                            isRunning = false;
                            Console.WriteLine("Вы вышли из программы.");
                        }
                        break;

                    default:
                        {
                            if (int.TryParse(userInput, out int value))
                            {
                                Console.WriteLine($"{value} - это число");

                                int[] temporaryNumbers = new int[numbers.Length + 1];

                                for (int i = 0; i < numbers.Length; i++)
                                {
                                    temporaryNumbers[i] = numbers[i];
                                }

                                temporaryNumbers[temporaryNumbers.Length - 1] = value;
                                numbers = temporaryNumbers;
                            }
                            else
                            {
                                Console.WriteLine("Это не число.");
                            }
                        }
                        break;
                }
            }
        }
    }
}
