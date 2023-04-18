using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                        fightingPit.ShowInfo();
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

            while (firstWarrior.Health >= 0 && secondWarrior.Health >= 0)
            {
                firstWarrior.UseSkill();
                secondWarrior.UseSkill();
                firstWarrior.TakeDamage(secondWarrior.Attack);
                secondWarrior.TakeDamage(firstWarrior.Attack);                
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

        public void ShowInfo()
        {
            Console.WriteLine("Список бойцов: ");

            ShowAllFighters();
        }

        private void ShowResultBattle(Warrior firstWarrior, Warrior secondWarrior)
        {
            if (firstWarrior.Health <= 0 && secondWarrior.Health <= 0)
            {
                Console.WriteLine("Ничья, оба бойца мертвы.");
            }
            else if (firstWarrior.Health <= 0)
            {
                Console.WriteLine($"Победил: {secondWarrior.Name}.");
            }
            else if (secondWarrior.Health <= 0)
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
            Health = health;            
            Armor = armor;
        }

        public string Name { get; private set; }
        public int Attack;
        public int Health;
        public int Armor;
        public double AttackSpeed;

        public void ShowInfo()
        {
            Console.WriteLine($"Имя бойца: {Name}, атака: {Attack}, здоровье: {Health}, броня: {Armor}.");
        }

        public abstract void UseSkill();

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
            Console.WriteLine($"{Name} получил {damage}, осталось {Health} и {Armor}.");
        }
    }

    class Knight : Warrior
    {
        public Knight() : base("Артур", 100, 100, 150) { }

        public override void UseSkill()
        {
            Armor += 50;
        }
    }

    class Barbarian : Warrior
    {
        public Barbarian() : base("Тормунд", 200, 1200) { }

        public override void UseSkill()
        {
            Attack += 100;
        }
    }

    class Archer : Warrior
    {
        public Archer() : base("Людвик", 120, 700, 25) { }

        public override void UseSkill()
        {
            Attack *= 2;
        }
    }

    class Gladiator : Warrior
    {
        public Gladiator() : base("Спартак", 220, 90, 30) { }

        public override void UseSkill()
        {
            Armor -= 15;
        }
    }

    class Wizard : Warrior
    {
        public Wizard() : base("Истари", 70, 290) { }

        public override void UseSkill()
        {
            Health *= 5;
        }
    }
}