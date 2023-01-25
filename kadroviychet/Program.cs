using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kadroviychet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossier = "1";
            const string OutputDossier = "2";
            const string DeleteDossier = "3";
            const string Exit = "4";

            bool isPlaying = true;
            Dictionary<string, string> postAndFullnames = new Dictionary<string, string>();

            Console.WriteLine($"{AddDossier} - добавить досье.");
            Console.WriteLine($"{OutputDossier} - вывести все досье.");
            Console.WriteLine($"{DeleteDossier} - удалить досье.");
            Console.WriteLine($"{Exit} - выход.");

            while (isPlaying)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossier:
                        CreateDossier(postAndFullnames);
                        break;

                    case OutputDossier:
                        OutputAllDossier(postAndFullnames);
                        break;

                    case DeleteDossier:
                        DisposeDossier(ref postAndFullnames);
                        break;

                    case Exit:
                        isPlaying = false;
                        break;
                }
            }
        }

        static void CreateDossier(Dictionary<string, string> postAndFullNames)
        {
            Console.WriteLine("Введите фамилию и имя:");
            string fullName = Console.ReadLine();

            if (postAndFullNames.ContainsKey(fullName) == false)
            {
                Console.WriteLine("Введите должность: ");
                string post = Console.ReadLine();
                postAndFullNames.Add(fullName, post);
            }
            else
            {
                Console.WriteLine("Такой сотрудник уже существует.");
            }
        }

        static void OutputAllDossier(Dictionary<string, string> postAndFullNames)
        {
            foreach (var employee in postAndFullNames)
            {
                Console.Write($"| Фамилия и Имя - {employee.Key}, должность - {employee.Value} |");
            }
        }

        static void DisposeDossier(ref Dictionary<string, string> postAndFullNames)
        {
            Console.WriteLine("Введите фамилию и имя сотрудника для удаления:");
            string userInput = Console.ReadLine();

            if (postAndFullNames.Remove(userInput) == true)
            {
                postAndFullNames.Remove(userInput);
                Console.WriteLine("Сотрудник удален.");
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет.");
            }

        }
    }
}
