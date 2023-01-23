using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slovo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> words = FillWords();

            bool isWorking = true;
            string exit = "Выход.";

            while (isWorking)
            {
                Console.WriteLine($"Введите слово для проверки, либо для выхода из программы введите: {exit}");
                string userInput = Console.ReadLine();

                if (userInput == exit)
                {
                    isWorking = false;
                }
                else if (words.ContainsKey(userInput))
                {
                    Console.WriteLine(words[userInput]);
                }
                else
                {
                    Console.WriteLine("Такого слова нет.");
                }

            }
        }

        static Dictionary<string, string> FillWords()
        {
            return new Dictionary<string, string>()
            {
                ["Собака"] = "Такое слово есть.",
                ["Пиво"] = "Такое слово есть.",
                ["Дорога"] = "Такое слово есть.",
                ["Дом"] = "Такое слово есть.",
                ["Парк"] = "Такое слово есть.",
            };
        }
    }
}