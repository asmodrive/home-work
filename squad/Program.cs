using System;
using System.Collections.Generic;

namespace squad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandStartBattle = "1";
            const string CommandShowPlatoon = "2";
            const string CommandExit = "3";

            War war = new War();

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandStartBattle} - начать сражение,\n{CommandShowPlatoon} - показать солдат во взводе,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandStartBattle:
                        war.StartBattle();
                        break;

                    case CommandShowPlatoon:
                        war.ShowListPlatoon();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class War
    {
        private List<Platoon> _firstPlatoon;

        private List<Platoon> _secondPlatoon;

        public War()
        {
            CreateListSoldiers();
        }

        public void CreateListSoldiers()
        {
            _firstPlatoon = new List<Platoon>()
            {
                new Platoon("Сэм", 150, 100, 20),
                new Platoon("Майкл", 150, 100, 20),
                new Platoon("Джери", 150, 100, 20),
                new Platoon("Том", 150, 100, 20),
                new Platoon("Уолтер", 150, 100, 20),
                new Platoon("Джейсон", 150, 100, 20)
            };

            _secondPlatoon = new List<Platoon>()
            {
                new Platoon("Робин", 150, 100, 20),
                new Platoon("Гари", 150, 100, 20),
                new Platoon("Алекс", 150, 100, 20),
                new Platoon("Джордж", 150, 100, 20),
                new Platoon("Уильям", 150, 100, 20),
                new Platoon("Дуглас", 150, 100, 20)
            };
        }

        public void StartBattle()
        {
            while (_firstPlatoon.Count >= 0 && _secondPlatoon.Count >= 0)
            {
                
            }
        }


        public void ShowListPlatoon()
        {
            Console.WriteLine("Список солдат в первом взводе:\n ");

            foreach (Platoon platoon in _firstPlatoon)
            {
                platoon.ShowInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Список солдат во втором взводе:\n ");

            foreach (Platoon platoon in _secondPlatoon)
            {
                platoon.ShowInfo();
                Console.WriteLine();
            }
        }
    }

    class Platoon
    {
        public Platoon(string name, int attack, int healph, int armor)
        {
            Name = name;
            Attack = attack;
            Healph = healph;
            Armor = armor;
        }

        public string Name { get; private set; }
        public int Attack { get; protected set; }
        public int Healph { get; protected set; }
        public int Armor { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя бойца: {Name}, атака: {Attack}, здоровье: {Healph}, броня: {Armor}.");
        }

        public void TakeDamage(int damage)
        {
            Healph -= damage - Armor;
            Console.WriteLine($"{Name} получил {damage}, осталось {Healph} и {Armor}.");
        }

        public void GiveDamage(Platoon platoon)
        {
            platoon.TakeDamage(Attack);
        }
    }
}
