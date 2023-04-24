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
        private Platoon _firstPlatoon;
        private Platoon _secondPlatoon;

        public void StartBattle()
        {
            _firstPlatoon = new Platoon(true);
            _secondPlatoon = new Platoon(false);

            while (_firstPlatoon.GetCountSoldiers() && _secondPlatoon.GetCountSoldiers())
            {
                _firstPlatoon.ShowInfo();
                _secondPlatoon.ShowInfo();
                var firstSoldier = _firstPlatoon.GetSoldier();
                var secondSoldier = _secondPlatoon.GetSoldier();
                firstSoldier.UseSkillAttack();
                secondSoldier.UseSkillDefence();
                firstSoldier.Attack(secondSoldier);
                secondSoldier.Attack(firstSoldier);
                _firstPlatoon.RemoveDeadSoldiers();
                _secondPlatoon.RemoveDeadSoldiers();
                Console.ReadKey();
            }

            Console.WriteLine("Битва окончена!");
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private Random _random = new Random();

        public Platoon(bool even)
        {
            var soldiers = ListFighters();

            for (int i = 0; i < soldiers.Count; i++)
            {
                if (i % 2 == 0 && even || i % 2 != 0 && even == false)
                {
                    _soldiers.Add(soldiers[i]);
                }
            }
        }

        private List<Soldier> ListFighters()
        {
            var soldiers = new List<Soldier>()
        {
                new Soldier("Сэм", 5, 100, 20),
                new Soldier("Майкл", 15, 100, 20),
                new Soldier("Джери", 10, 100, 20),
                new Soldier("Том", 25, 100, 20),
                new Soldier("Уолтер", 40, 100, 20),
                new Soldier("Джейсон", 20, 100, 20),
                new Soldier("Робин", 7, 100, 20),
                new Soldier("Гари", 60, 100, 20),
                new Soldier("Алекс", 30, 100, 20),
                new Soldier("Джордж", 10, 100, 20),
                new Soldier("Уильям", 32, 100, 20),
                new Soldier("Дуглас", 17, 100, 20)
        };

            return soldiers;
        }

        public bool GetCountSoldiers()
        {
            return _soldiers.Count > 0;
        }

        public void RemoveDeadSoldiers()
        {
            for (int i = _soldiers.Count - 1; i >= 0; i--)
            {
                if (_soldiers[i].Healph <= 0)
                {
                    _soldiers.RemoveAt(i);
                    Console.WriteLine($"В отряде осталось {_soldiers.Count} бойцов");
                }
            }
        }

        public void ShowInfo()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }

        public Soldier GetSoldier()
        {
            Random random = new Random();

            return _soldiers[random.Next(0, _soldiers.Count)];
        }
    }

    class Soldier
    {
        public Soldier(string name, int attack, int healph, int armor)
        {
            Name = name;
            Damage = attack;
            Healph = healph;
            Armor = armor;
        }

        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Healph { get; protected set; }
        public int Armor { get; protected set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя бойца: {Name}, атака: {Damage}, здоровье: {Healph}, броня: {Armor}.");
        }

        public void TakeDamage(int damage)
        {
            if (damage > Armor)
            {
                Healph -= damage - Armor;
            }

            Console.WriteLine($"{Name} получил {damage}, осталось {Healph} и {Armor}.");
        }

        public void Attack(Soldier soldier)
        {
            soldier.TakeDamage(Damage);
        }

        public void UseSkillAttack()
        {
            int damageBuff = 5;

            Damage *= damageBuff;
        }

        public void UseSkillDefence()
        {
            int healphBuff = 150;

            Healph += healphBuff;
        }
    }
}