using System;
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
           Dictionary<string, string> words = new Dictionary<string, string>();

            words.Add("Собака", "Такое слово есть.");
            words.Add("Пиво", "Такое слово есть.");
            words.Add("Дорога", "Такое слово есть.");
            words.Add("Дом", "Такое слово есть.");
            words.Add("Парк", "Такое слово есть.");
            string userInput = Console.ReadLine();

            if (words.ContainsKey(userInput))
            {
                Console.WriteLine(words[userInput]);
            }
            else
            {
                Console.WriteLine("Такого слова нет.");
            }
        }
            
    }

    
}