using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace soldat
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
        private List<Soldier> _soldiers;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandGetData = "1";
            const string CommandExit = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandGetData} - получить данные,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandGetData:
                        GetData();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private List<Soldier> Create()
        {
            _soldiers = new List<Soldier>
            {
                new Soldier("Дуглас", "пистолет", "сержант", 10),
                new Soldier("Сэм", "автомат", "полковник", 10),
                new Soldier("Брайн", "карабин", "рядовой", 10),
                new Soldier("Майкл", "ружье", "капрал", 10),
                new Soldier("Томас", "молоток", "рядовой", 10),
                new Soldier("Эндрю", "кувалда", "капитан", 10),
                new Soldier("Брюс", "тесак", "сержант", 10),
                new Soldier("Лемюэль", "винтовка", "майор", 10),
                new Soldier("Луис", "дробовик", "рядовой", 10),
                new Soldier("Роджер", "нож", "лейтенант", 10)
            };

            return _soldiers;
        }

        private void GetData()
        {
            Console.WriteLine("Введите звание:");
            string title = Console.ReadLine();
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            var foundSoldier = _soldiers.Where(soldier => soldier.Title == title && soldier.Name == name);

            foreach (var soldier in foundSoldier)
            {
                Console.WriteLine($"{soldier.Name} {soldier.Title}");
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string armament, string title, int tour)
        {
            Name = name;
            Armament = armament;
            Title = title;
            Tour = tour;
        }

        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Title { get; private set; }
        public int Tour { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, вооружение: {Armament}, звание: {Title}, срок службы: {Tour}.");
        }
    }
}
