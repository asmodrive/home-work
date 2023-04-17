using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_pit
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Warrior
    {
        public Warrior(string name, int attack, int health, int armor)
        {
            Name = name;
            Attack = attack;
            Health = health;
            Armor = armor;
        }

        public string Name { get; private set; }
        public int Attack { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    class Knight : Warrior
    {
        public Knight(string name, int attack, int health, int armor) : base(name, attack, health, armor) { }



        public void RaiseShield()
        {

        }
    }

    class Barbarian : Warrior
    {
        public Barbarian(string name, int attack, int health, int armor) : base(name, attack, health, armor) { }

        public void Stun()
        {

        }
    }

    class Archer : Warrior
    {
        public Archer(string name, int attack, int health, int armor) : base(name, attack, health, armor) { }

        public void GetCrossbow()
        {

        }
    }

    class Gladiator : Warrior
    {
        public Gladiator(string name, int attack, int health, int armor) : base(name, attack, health, armor) { }

        public void GetSecondSword()
        {

        }
    }

    class Wizard : Warrior
    {
        public Wizard(string name, int attack, int health, int armor) : base(name, attack, health, armor) { }

        public void RaiseProtectiveBall()
        {

        }
    }
}
