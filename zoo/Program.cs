using System.Collections.Generic;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        var zoo = new Zoo();

        zoo.FillEnclosures();
        zoo.Work();
    }
}

class Zoo
{
    public Zoo()
    {
        Aviaries = new List<Aviary>()
            {
                new Aviary("львы", 1),
                new Aviary("слоны", 2),
                new Aviary("обезьяны", 3),
                new Aviary("гиены", 4)
            };
    }

    public List<Aviary> Aviaries { get; private set; }
    public Aviary GetEnclosure(int index) => Aviaries[index];

    public void FillEnclosures()
    {
        var allGenders = new List<string>()
            {
                "самец",
                "самка"
            };

        Random random = new Random();

        int maxAnimals = 6;

        foreach (var enclosure in Aviaries)
        {
            Animal newAnimal;
            string gender;
            int quantityOfAnimals = random.Next(maxAnimals + 1);

            for (int i = 0; i < quantityOfAnimals; i++)
            {
                gender = allGenders[random.Next(allGenders.Count)];
                quantityOfAnimals = random.Next(maxAnimals + 1);

                switch (enclosure.Name)
                {
                    case "Лев":
                        newAnimal = new Lion(gender);
                        break;

                    case "Слон":
                        newAnimal = new Elefant(gender);
                        break;

                    case "Обезьяна":
                        newAnimal = new Monkey(gender);
                        break;

                    default:
                        newAnimal = new Hyena(gender);
                        break;
                }

                enclosure.AddNewAnimal(newAnimal);
            }
        }
    }

    public void Work()
    {
        bool isWorking = true;
        int userInput;

        while (isWorking)
        {
            Console.Clear();
            ShowAviaries();
            int.TryParse(Console.ReadLine(), out userInput);

            if (userInput > 0 && userInput <= Aviaries.Count)
            {
                Aviaries[userInput - 1].ShowInfo();
            }
            else if (userInput == Aviaries.Count + 1)
            {
                isWorking = false;
            }
        }
    }

    private void ShowAviaries()
    {
        for (int i = 0; i < Aviaries.Count; i++)
        {
            Console.WriteLine($"Для выбора вольера \"{Aviaries[i].Name}\" ведите {Aviaries[i].Numbers} ");
        }

        Console.WriteLine($"Чтобы покинуть зоопарк введите {Aviaries.Count + 1}");
    }
}

class Aviary
{
    private List<Animal> _animals;

    public Aviary(string name, int id)
    {
        Name = name;
        Numbers = id;
        _animals = new List<Animal>();
    }

    public int Numbers { get; private set; }
    public string Name { get; private set; }

    public void ShowInfo()
    {
        foreach (var animal in _animals)
        {
            animal.ShowInfo();
        }
    }

    public void AddNewAnimal(Animal animal)
    {
        _animals.Add(animal);
    }
}

abstract class Animal
{
    public Animal(string gender)
    {
        Gender = gender;
    }

    public string Name { get; protected set; }
    public string Gender { get; protected set; }
    public string Voice { get; protected set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Животное: {Name}, пол: {Gender}, звук: {Voice}");
    }
}

class Lion : Animal
{
    public Lion(string gender) : base(gender)
    {
        Name = "лев";
        Voice = "рычит!";
        Gender = gender;
    }
}

class Elefant : Animal
{
    public Elefant(string gender) : base(gender)
    {
        Name = "слон";
        Voice = "Уууууу!";
        Gender = gender;
    }
}

class Monkey : Animal
{
    public Monkey(string gender) : base(gender)
    {
        Name = "обезьяна";
        Voice = "ъуъ";
        Gender = gender;
    }
}

class Hyena : Animal
{
    public Hyena(string gender) : base(gender)
    {
        Name = "гиена";
        Voice = "скулит";
        Gender = gender;
    }
}