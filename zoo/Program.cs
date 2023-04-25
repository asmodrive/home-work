using System;
using System.Collections.Generic;
using System.Threading;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Excursions();
        }
    }

    class Zoo
    {
        const string CommandEntry = "1";
        const string CommandExit = "2";

        private List<Aviary> _aviaries = new List<Aviary>();

        public void Excursions()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Вы попали на экскурсию в зоопарк, для доступа к вольерам введите:{CommandEntry}, для выхода из программы введите {CommandExit}.");

                switch (Console.ReadLine())
                {
                    case CommandEntry:
                        LookAviaries();
                        break;

                        case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        public void LookAviaries()
        {
            bool isWorking = true;

            while(isWorking)
            {
                ShowAviary();
                Console.WriteLine("Введите интересующий вас номер вольера:");

                bool isCorrect = int.TryParse(Console.ReadLine(), out int userInput);

                if (isCorrect == false)
                {
                    Console.WriteLine("Попробуйте еще раз.");
                }
                else if (userInput > _aviaries.Count)
                {

                }
                else
                {
                    Console.WriteLine("Такого вольера нет.");
                }
            }
        }

        public void ShowAviary()
        {
            foreach (Aviary aviary in _aviaries)
            {

            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals;
        public int Number { get; private set; }

        public Aviary()
        {
            CreateAviary();
        }

        private void CreateAviary()
        {
            _animals = new List<Animal>()
            {
                new Lion(),
                new Ostrich(),
                new Tiger(),
                new Baboon()
            };
        }
        private void ShowAllAnimals()
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                Console.Write(i + ". ");
                _animals[i].ShowInfo();
            }
        }

        public void ShowListAnimals()
        {
            Console.WriteLine("Список животных: ");

            ShowAllAnimals();
        }
    }

    class Animal
    {
        public Animal(string type, string voice)
        {
            Type = type;
            Voice = voice;
            Gender = GetGender();
        }

        public string Type { get; private set; }
        public string Voice { get; private set; }
        public string Gender { get; private set; }

        public string GetGender()
        {
            Random random = new Random();
            int minValue = 0;
            int maxValue = 2;
            int chooseGender = random.Next(minValue, maxValue);

            if (chooseGender == 0)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Животное: {Type}, гендер: {Gender}, звук: {Voice}.");
        }
    }

    class Lion : Animal
    {
        public Lion() : base("Лев", "рычит") { }
    }

    class Ostrich : Animal
    {
        public Ostrich() : base("Лев", "рычит") { }
    }

    class Tiger : Animal
    {
        public Tiger() : base("Лев", "рычит") { }
    }

    class Baboon : Animal
    {
        public Baboon() : base("Лев", "рычит") { }
    }
}