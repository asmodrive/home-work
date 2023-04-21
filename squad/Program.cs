using System;
using System.Collections.Generic;

namespace squad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandStartBattle = "1";
            const string CommandExit = "2";

            War war = new War();

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandStartBattle} - начать сражение,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandStartBattle:
                        war.StartBattle();
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
        public void StartBattle()
        {
            var platoon = new Platoon();

            while (platoon.CheckSoldiersCount())
            {
                platoon.ShowSoldiers();
                var firstSoldier = platoon.GetFirstSquadSoldier();
                var secondSoldier = platoon.GetSecondSquadSoldier();
                firstSoldier.UseSkillAttack();
                secondSoldier.UseSkillDefence();
                firstSoldier.GiveDamage(secondSoldier);
                secondSoldier.GiveDamage(firstSoldier);
                platoon.RemoveDeadSoldiers();
                Console.ReadKey();
            }

            Console.WriteLine("Битва окончена!");
        }
    }

    class Platoon
    {
        private List<Soldier> _firstPlatoon;
        private List<Soldier> _secondPlatoon;

        public Platoon()
        {
            CreateListSoldiers();
        }

        public void CreateListSoldiers()
        {
            _firstPlatoon = new List<Soldier>()
            {
                new Soldier("Сэм", 5, 100, 20),
                new Soldier("Майкл", 15, 100, 20),
                new Soldier("Джери", 10, 100, 20),
                new Soldier("Том", 25, 100, 20),
                new Soldier("Уолтер", 40, 100, 20),
                new Soldier("Джейсон", 20, 100, 20)
            };

            _secondPlatoon = new List<Soldier>()
            {
                new Soldier("Робин", 7, 100, 20),
                new Soldier("Гари", 60, 100, 20),
                new Soldier("Алекс", 30, 100, 20),
                new Soldier("Джордж", 10, 100, 20),
                new Soldier("Уильям", 32, 100, 20),
                new Soldier("Дуглас", 17, 100, 20)
            };
        }

        public Soldier GetFirstSquadSoldier()
        {
            Random random = new Random();

            return _firstPlatoon[random.Next(0, _firstPlatoon.Count)];
        }

        public Soldier GetSecondSquadSoldier()
        {
            Random random = new Random();

            return _secondPlatoon[random.Next(0, _secondPlatoon.Count)];
        }

        public void ShowPlatoon(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }

        public void ShowSoldiers()
        {
            ShowPlatoon(_firstPlatoon);

            ShowPlatoon(_secondPlatoon);
        }

        public bool CheckSoldiersCount()
        {
            if (_firstPlatoon.Count > 0 && _secondPlatoon.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void RemoveDeadSoldiers()
        {
            for (int i = _firstPlatoon.Count - 1; i >= 0; i--)
            {
                if (_firstPlatoon[i].Healph <= 0)
                {
                    _firstPlatoon.RemoveAt(i);
                    Console.WriteLine($"В первом отряде осталось {_firstPlatoon.Count} бойцов");
                }
            }

            for (int i = _secondPlatoon.Count - 1; i >= 0; i--)
            {
                if (_secondPlatoon[i].Healph <= 0)
                {
                    _secondPlatoon.RemoveAt(i);
                    Console.WriteLine($"Во втором отряде осталось {_secondPlatoon.Count} бойцов");
                }
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, int attack, int healph, int armor)
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

        public void GiveDamage(Soldier soldier)
        {
            soldier.TakeDamage(Attack);
        }

        public void UseSkillAttack()
        {
            int damageBuff = 5;

            Attack *= damageBuff;
        }

        public void UseSkillDefence()
        {
            int healphBuff = 150;

            Healph += healphBuff;
        }
    }
}