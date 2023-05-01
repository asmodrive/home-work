using System;
using System.Collections.Generic;
using System.Linq;

namespace spisolSoldat
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
        private List<Soldier> _firstPlatoon;
        public List<Soldier> _secondPlatoon;

        public DataBase()
        {
            CreateFirstPlatoon();
            CreateSecondPlatoon();
        }

        public void StartWork()
        {
            const string CommandUnionTeam = "1";
            const string CommandExit = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandUnionTeam} - перевести бойцов с фамилией на букву 'Б' в отряд №2,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandUnionTeam:
                        UnionPlatoons();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private void UnionPlatoons()
        {
            Console.WriteLine("Первый взвод до распределения:");
            ShowSoldiers(_firstPlatoon);
            Console.WriteLine("Второй взвод до распределения:");
            ShowSoldiers(_secondPlatoon);
            Console.WriteLine();
            var soldiers = _firstPlatoon.Where(soldier => soldier.Name.Contains("Б"));
            _secondPlatoon = _secondPlatoon.Union(soldiers).ToList();
            _firstPlatoon = _firstPlatoon.Except(soldiers).ToList();
            Console.WriteLine("Первый взвод:");
            ShowSoldiers(_firstPlatoon);
            Console.WriteLine("Второй взвод:");
            ShowSoldiers(_secondPlatoon);
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }
        }

        private List<Soldier> CreateFirstPlatoon()
        {
            _firstPlatoon = new List<Soldier>
            {
                new Soldier("Бронсон", "сержант"),
                new Soldier("Дуглас", "сержант"),
                new Soldier("Сэм", "сержант"),
                new Soldier("Корнет", "сержант"),
                new Soldier("Дуглас", "сержант"),
                new Soldier("Брен", "сержант"),
                new Soldier("Дуглас", "сержант"),
                new Soldier("Барскетвили", "сержант")
            };

            return _firstPlatoon;
        }
        private List<Soldier> CreateSecondPlatoon()
        {
            _secondPlatoon = new List<Soldier>
            {
                new Soldier("Думский", "сержант"),
                new Soldier("Водный", "сержант"),
                new Soldier("Сэм", "сержант"),
                new Soldier("Брайн", "сержант"),
                new Soldier("Дрюсель", "сержант")
            };

            return _secondPlatoon;
        }
    }

    class Soldier
    {
        public Soldier(string name, string title)
        {
            Name = name;
            Title = title;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, звание: {Title}.");
        }
    }
}
