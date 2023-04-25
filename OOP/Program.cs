using System;
using System.Collections.Generic;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartExcursion();
            Console.ReadLine();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public void StartExcursion()
        {
            CreativeAviary(5);
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопар. У нас есть {_aviaries.Count} вальеров с животными " +
                    "\nДля налало экскурии, продолжения введите \"1\"" +
                    ". Выход из зоопарка \"exit\"");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAviary();
                        break;
                    case "exit":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Хм.. Такой команды нету.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreativeAviary(int numberOfAviary)
        {
            for (int i = 0; i < numberOfAviary; i++)
            {
                _aviaries.Add(new Aviary());
            }
        }

        private void ShowAviary()
        {
            Console.Write("На какой вольер вы хотите посмотреть?: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberAviary);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
            }
            else if (inputNumberAviary > 0 && inputNumberAviary < _aviaries.Count)
            {
                _aviaries[inputNumberAviary - 1].ShowAnimal();
            }
            else
            {
                Console.WriteLine("Вальера с таким номером в зоопарке нету.");
            }
        }
    }

    class Aviary
    {
        private Dictionary<int, Animal> _animals = new Dictionary<int, Animal>();
        private Random _random = new Random();
        private string[] _listAnimals = new string[] { "Tiger", "Sheep", "Giraffe", "Elephant", "Crocodile" };

        public Aviary()
        {
            CreativeAnimal(5);
        }

        public void ShowAnimal()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Value.Name}. Gender - {animal.Value.Gender}. Voce - {animal.Value.Voice}");
            }
        }

        private void CreativeAnimal(int numberOfAnimals)
        {
            int animalId = _random.Next(0, _listAnimals.Length);

            for (int i = 0; i < numberOfAnimals; i++)
            {
                _animals.Add(i, GetAnimal(animalId));
            }
        }

        private Animal GetAnimal(int animalId)
        {
            switch (_listAnimals[animalId])
            {
                case "Tiger":
                    return new Animal("Тигр", "Р-р-р");
                case "Sheep":
                    return new Animal("Овца", "Беее");
                case "Giraffe":
                    return new Animal("Жираф", "Хрум-хрум");
                case "Elephant":
                    return new Animal("Бегемот", "Хрю-хрю");
                case "Crocodile":
                    return new Animal("Крокодил", "Клоц-клоц");
            }

            return null;
        }
    }

    class Animal
    {
        private Random _random = new Random();
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; private set; }

        public Animal(string name, string voice)
        {
            Name = name;
            Gender = GetGenderAnimal();
            Voice = voice;
        }

        private string GetGenderAnimal()
        {
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;
            int gender = _random.Next(minimumNumberGender, maximumNumberGender);

            if (gender == 1)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }
    }
}