using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bolnitsa
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
        private List<Patient> _patients;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandSortingByname = "1";
            const string CommandSortingByAge = "2";
            const string CommandConclusionDisease = "3";
            const string CommandExit = "4";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Выберите номер операции:\n{CommandSortingByname} - сортировка по ФИО,\n{CommandSortingByAge} - сортировка по возрасту,\n" +
                    $"{CommandConclusionDisease} - вывести пациента с определенной болезнью,\n{CommandExit} - выход из программы.");

                switch (Console.ReadLine())
                {
                    case CommandSortingByname:
                        SortingName();
                        break;

                    case CommandSortingByAge:
                        SortingAge();
                        break;

                    case CommandConclusionDisease:
                        ShowSelectedDisease();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private List<Patient> Create()
        {
            _patients = new List<Patient>
            {
                new Patient("Зубенко Михаил Петрович", 20, "психоз"),
                new Patient("Чарльз Мэнсон", 48, "перелом"),
                new Patient("Пабло Эскобак", 54, "covid"),
                new Patient("Джек-потрошитель", 140, "опухоль мозга"),
                new Patient("Дик Турпин", 89, "covid"),
                new Patient("Чарльз Бронсон", 14, "бактериоз"),
            };

            return _patients;
        }

        public void SortingName()
        {
            var foundPatients = _patients.OrderBy(patient => patient.Name);

            foreach (var patient in foundPatients)
            {
                patient.ShowInfo();
            }
        }

        public void SortingAge()
        {
            var foundPatients = _patients.OrderBy(patient => patient.Age);

            foreach (var patient in foundPatients)
            {
                patient.ShowInfo();
            }
        }

        public void ShowSelectedDisease()
        {
            Console.WriteLine("Введите болезнь:");
            string userInput = Console.ReadLine();

            var foundPatients = _patients.Where(criminal => criminal.Disease == userInput);

            foreach (var patient in foundPatients)
            {
                patient.ShowInfo();
            }
        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name}, возраст: {Age}, болезнь: {Disease}.");
        }
    }
}
