using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace detektiv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.StartWork();
        }
    }

    class DataBase
    {
        private List<Criminal> _criminals;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandStartWork = "1";
            const string CommandStopWork = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции: {CommandStartWork} - начало работы, {CommandStopWork} - выход из программы.");

                switch (Console.ReadLine())
                {
                    case CommandStartWork:
                        FindCulprit();
                        break;

                    case CommandStopWork:
                        isWorking = false;
                        break;
                }
            }
        }

        private void FindCulprit()
        {
            bool isConcluded = false;
            string nationality;
            Console.WriteLine("Введите рост:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int height);
            Console.Write("Введите вес:");
            isCorrect = int.TryParse(Console.ReadLine(), out int weight);
            Console.WriteLine("Введите национальность:");
            nationality = Console.ReadLine();

            if (isCorrect)
            {
                var foundCriminal = _criminals.Where(criminal => criminal.Concluded == isConcluded && criminal.Nationality == nationality && criminal.Weight == weight && criminal.Height == height);

                foreach (var criminal in foundCriminal)
                {
                    criminal.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
        }

        private List<Criminal> Create()
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Зубенко Михаил Петрович", false, 150, 100, "еврей"),
                new Criminal("Чарльз Мэнсон", true, 150, 100, "американец"),
                new Criminal("Пабло Эскобак", false, 150, 100, "колумбиец"),
                new Criminal("Джек-потрошитель", true, 150, 100, "англичанин"),
                new Criminal("Дик Турпин", false, 150, 100, "англичанин"),
                new Criminal("Чарльз Бронсон", false, 150, 100, "англичанин"),
            };

            return _criminals;
        }
    }

    class Criminal
    {
        public Criminal(string name, bool concluded, int height, int weight, string nationality)
        {
            Name = name;
            Concluded = concluded;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; private set; }
        public bool Concluded { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name}, заключен: {Concluded}, рост: {Height}, вес {Weight}, национальность: {Nationality}.");
        }
    }
}