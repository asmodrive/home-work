using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player hero = new Player("Артур", 100, 75, 68, 26);

            hero.ShowCharacteristics();
        }
    }

    class Player
    {
        public string Name;
        public int Health;
        public int Armor;
        public float Experience;
        public int Endurance;

        public Player (string name, int health, int armor, float experience, int energy)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Experience = experience;
            Endurance = energy;
        }

        public void ShowCharacteristics()
        {
            Console.WriteLine($"Имя игрока: {Name}.\nЗдоровье игрока: {Health}.\nБроня игрока: {Armor}.\nОчки опыта игрока: {Experience}.\nОстаток выносливости: {Endurance}.");
        }
    }
}
