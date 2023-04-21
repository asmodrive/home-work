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
        private Platoon _firstPlatoon = new Platoon(new List<Soldier>
        {
                new Soldier("Сэм", 5, 100, 20),
                new Soldier("Майкл", 15, 100, 20),
                new Soldier("Джери", 10, 100, 20),
                new Soldier("Том", 25, 100, 20),
                new Soldier("Уолтер", 40, 100, 20),
                new Soldier("Джейсон", 20, 100, 20)
        }
        );

        private Platoon _secondPlatoon = new Platoon(new List<Soldier>
            {
               new Soldier("Робин", 7, 100, 20),
                new Soldier("Гари", 60, 100, 20),
                new Soldier("Алекс", 30, 100, 20),
                new Soldier("Джордж", 10, 100, 20),
                new Soldier("Уильям", 32, 100, 20),
                new Soldier("Дуглас", 17, 100, 20)
            }
        );

        public void StartBattle()
        {
            while (_firstPlatoon.GetCountSoldiers() && _secondPlatoon.GetCountSoldiers())
            {
                _firstPlatoon.ShowPlatoon();
                var firstSoldier = _firstPlatoon.GetSquadSoldier();
                var secondSoldier = _secondPlatoon.GetSquadSoldier();
                firstSoldier.UseSkillAttack();
                secondSoldier.UseSkillDefence();
                firstSoldier.GiveAttack(secondSoldier);
                secondSoldier.GiveAttack(firstSoldier);
                _firstPlatoon.RemoveDeadSoldiers();
                _secondPlatoon.RemoveDeadSoldiers();
                Console.ReadKey();
            }

            Console.WriteLine("Битва окончена!");
        }

        public void ShowPlatoon(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(List<Soldier> soldiers)
        {
            _soldiers = soldiers;
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

        public void ShowPlatoon()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowInfo();
            }

            Console.WriteLine();
        }

        public Soldier GetSquadSoldier()
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
            if (damage < Armor)
            {
                Armor = damage;
            }

            Healph -= damage - Armor;
            Console.WriteLine($"{Name} получил {damage}, осталось {Healph} и {Armor}.");


        }

        public void GiveAttack(Soldier soldier)
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