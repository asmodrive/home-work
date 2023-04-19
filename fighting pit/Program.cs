using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace fighting_pit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandChooseFighter = "1";
            const string CommandShowFighters = "2";
            const string Exit = "3";

            FightingPit fightingPit = new FightingPit();

            fightingPit.CreateListFighters();

            bool isWorking = true;

            while (isWorking)
            {
               Console.WriteLine($"Введите номер операции:\n{CommandChooseFighter} - выбрать бойца и начать поединок,\n{CommandShowFighters} - показать бойца,\n{Exit} - выйти из бойцовской ямы.");

                switch (Console.ReadLine())
                {
                    case CommandChooseFighter:
                        fightingPit.StartBattle();                        
                        break;

                    case CommandShowFighters:
                        fightingPit.ShowListFighters();
                        break;

                    case Exit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class FightingPit 
    {
        private List<Warrior> _warriors;

        public void CreateListFighters()
        {
            _warriors = new List<Warrior>()
            {
                new Knight(),
                new Barbarian(),
                new Archer(),
                new Gladiator(),
                new Wizard()
            };
        }
        public void StartBattle()
        {
            ChooseFighters(out Warrior firstWarrior, out Warrior secondWarrior);

            Console.WriteLine($"Вы выбрали бойцов, начинается схватка {firstWarrior.Name} и {secondWarrior.Name}.");

            while (firstWarrior.Healph >= 0 && secondWarrior.Healph >= 0)
            {
                firstWarrior.UseSkill();
                secondWarrior.UseSkill();
                firstWarrior.GiveDamage(secondWarrior);
                secondWarrior.GiveDamage(firstWarrior);                
            }

            ShowResultBattle(firstWarrior, secondWarrior);
        }

        public void ChooseFighters(out Warrior firstWarrior, out Warrior secondWarrior)
        {
            firstWarrior = null;
            secondWarrior = null;

            while (firstWarrior == null || secondWarrior == null)
            {
                Console.WriteLine("Введите номер первого бойца:");

                firstWarrior = GetFighter();

                Console.WriteLine("Введите номер второго бойца:");

                secondWarrior = GetFighter();
            }
        }

        private Warrior GetFighter()
        {
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                if (_warriors.Count <= number)
                {
                    Console.WriteLine("Такого бойца нет");
                }
                else
                {
                    Console.WriteLine($"Вы выбрали: {_warriors[number].Name}");
                    return _warriors[number];
                }
            }

            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }

            return null;
        }

        private void ShowAllFighters()
        {
            for (int i = 0; i < _warriors.Count; i++)
            {
                Console.Write(i + ". ");
                _warriors[i].ShowInfo();
            }
        }

        public void ShowListFighters()
        {
            Console.WriteLine("Список бойцов: ");

            ShowAllFighters();
        }

        private void ShowResultBattle(Warrior firstWarrior, Warrior secondWarrior)
        {
            if (firstWarrior.Healph <= 0 && secondWarrior.Healph <= 0)
            {
                Console.WriteLine("Ничья, оба бойца мертвы.");
            }
            else if (firstWarrior.Healph <= 0)
            {
                Console.WriteLine($"Победил: {secondWarrior.Name}.");
            }
            else if (secondWarrior.Healph <= 0)
            {
                Console.WriteLine($"Победил: {firstWarrior.Name}.");
            }
        }
    }

    abstract class Warrior
    {
        private List<Warrior> _warriors = new List<Warrior>();

        public Warrior(string name, int attack, int health, int armor = 0)
        {
            Name = name;
            Attack = attack;
            Healph = health;            
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

        public abstract void UseSkill();

        public void TakeDamage(int damage)
        {
            Healph -= damage - Armor;
            Console.WriteLine($"{Name} получил {damage}, осталось {Healph} и {Armor}.");
        }

        public void GiveDamage(Warrior warrior)
        {
            warrior.TakeDamage(Attack);
        }
    }

    class Knight : Warrior
    {
        private int _armorBuff = 2;

        public Knight() : base("Артур", 100, 100, 150) { }

        public override void UseSkill()
        {
            Armor *= _armorBuff;
        }
    }

    class Barbarian : Warrior
    {
        private int _damageBuff = 100;

        public Barbarian() : base("Тормунд", 200, 1200) { }

        public override void UseSkill()
        {
            Attack += _damageBuff;
        }
    }

    class Archer : Warrior
    {
        private int _damageBuff = 40;

        public Archer() : base("Людвик", 120, 700, 25) { }

        public override void UseSkill()
        {
            Attack += _damageBuff;
        }
    }

    class Gladiator : Warrior
    {
        private int _damageBuff = 2;
        private int _armorBuff = 20;

        public Gladiator() : base("Спартак", 220, 90, 30) { }

        public override void UseSkill()
        {
            Attack *= _damageBuff;
            Armor -= _armorBuff;
        }
    }

    class Wizard : Warrior
    {
        private int _healphBuff = 5;

        public Wizard() : base("Истари", 70, 290) { }

        public override void UseSkill()
        {
            Healph *= _healphBuff;
        }
    }
}