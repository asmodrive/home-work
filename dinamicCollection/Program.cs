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
            const string AmountCommand = "сумма";
            const string ExitCommand = "выход";

            List<int> numbers = new List<int>();
            bool isWorking = true;

            Console.WriteLine($"Вводите числа, когда будете готовы просуммировать их введите : {AmountCommand}, для выхода из программы введите {ExitCommand}.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AmountCommand:
                        SumNumbers(numbers);
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        AddNumbers(numbers, userInput);
                       break;
                }
            }
        }

        static void SumNumbers(List<int> numbers)
        {
            int sumNumbers = 0;

            foreach (var number in numbers)
            {
                sumNumbers += number;
            }

            Console.WriteLine($"Сумма введёных чисел: {sumNumbers}.");
        }

        static void AddNumbers(List <int> numbers, string userInput)
        {
            bool isNumber = (int.TryParse(userInput, out int value));

            if (isNumber == true)
            {
                numbers.Add(value);
            }
            else
            {
                Console.WriteLine("Это не число.");
            }
        }
    }
}