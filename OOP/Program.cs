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
        private string _name;
        private int _health;
        private int _armor;
        private float _experience;
        private int _endurance;

        public Player (string name, int health, int armor, float experience, int energy) 
        {   
            _name = name;
            _health = health;
            _armor = armor;
            _experience = experience;
            _endurance = energy;
        }

        public void ShowCharacteristics()
        {
            Console.WriteLine($"Имя игрока: {_name}.\nЗдоровье игрока: {_health}.\nБроня игрока: {_armor}.\nОчки опыта игрока: {_experience}.\nОстаток выносливости: {_endurance}.");
        }
    }
}
