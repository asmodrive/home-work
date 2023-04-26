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
        Enclosures = new List<Enclosure>()
            {
                new Enclosure("львы", 1),
                new Enclosure("слоны", 2),
                new Enclosure("обезьяны", 3),
                new Enclosure("гиены", 4)
            };
    }

    public List<Enclosure> Enclosures { get; private set; }
    public Enclosure GetEnclosure(int index) =>
        Enclosures[index];

    public void FillEnclosures()
    {
        var allGenders = new List<string>()
            {
                "самец",
                "самка"
            };

        Random random = new Random();

        int maxAnimals = 6;

        foreach (var enclosure in Enclosures)
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
                    case "львы":
                        newAnimal = new Lion(gender);
                        break;

                    case "слоны":
                        newAnimal = new Elefant(gender);
                        break;

                    case "обезьяны":
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
            ShowCondition();
            int.TryParse(Console.ReadLine(), out userInput);

            if (userInput > 0 && userInput <= Enclosures.Count)
            {
                Enclosures[userInput - 1].Show();
            }
            else if (userInput == Enclosures.Count + 1)
            {
                isWorking = false;
            }
        }
    }

    private void ShowCondition()
    {
        for (int i = 0; i < Enclosures.Count; i++)
        {
            Console.WriteLine($"Для выбора вольера \"{Enclosures[i].Name}\" ведите {Enclosures[i].Id} ");
        }

        Console.WriteLine($"Чтобы покинуть зоопарк введите {Enclosures.Count + 1}");
    }
}

class Enclosure
{
    private List<Animal> _animals;

    public Enclosure(string name, int id)
    {
        Name = name;
        Id = id;
        _animals = new List<Animal>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

    public void Show()
    {
        Console.Clear();

        foreach (var animal in _animals)
        {
            animal.Show();
        }

        Console.ReadLine();
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
    public string Sound { get; protected set; }

    public abstract void Show();
}

class Lion : Animal
{
    public Lion(string gender) : base(gender)
    {
        Name = "лев";
        Sound = "Арррррр!";
        Gender = gender;
    }

    public override void Show()
    {
        Console.WriteLine($"{Name} {Gender}\n" +
                          $" {Sound}");
    }
}

class Elefant : Animal
{
    public Elefant(string gender) : base(gender)
    {
        Name = "слон";
        Sound = "Уууууу!";
        Gender = gender;
    }

    public override void Show()
    {
        Console.WriteLine($"{Name} {Gender}\n" +
                          $" {Sound}");
    }
}

class Monkey : Animal
{
    public Monkey(string gender) : base(gender)
    {
        Name = "обезьяна";
        Sound = "Уу-аа!";
        Gender = gender;
    }

    public override void Show()
    {
        Console.WriteLine($"{Name} {Gender}\n" +
                          $" {Sound}");
    }
}

class Hyena : Animal
{
    public Hyena(string gender) : base(gender)
    {
        Name = "гиена";
        Sound = "Хи-хи-хи!";
        Gender = gender;
    }

    public override void Show()
    {
        Console.WriteLine($"{Name} {Gender}\n" +
                          $" {Sound}");
    }
}