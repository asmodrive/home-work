using System.Collections.Generic;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        var zoo = new Zoo();

        zoo.FillAviary();
        zoo.Work();
    }
}

class Zoo
{
    private List<Aviary> _aviaries;
    const string CommandAviaryLions = "львы";
    const string CommandAviaryElephants = "слоны";
    const string CommandAviaryMonkeys = "обезьяны";
    const string CommandAviaryHyenes = "гиены";

    public Zoo()
    {
        _aviaries = new List<Aviary>()
            {
                new Aviary(CommandAviaryLions, 1),
                new Aviary(CommandAviaryElephants, 2),
                new Aviary(CommandAviaryMonkeys, 3),
                new Aviary(CommandAviaryHyenes, 4)
            };
    }

    public Aviary GetAviary(int index) => _aviaries[index];

    public void FillAviary()
    {
        

        var allGenders = new List<string>()
            {
                "самец",
                "самка"
            };

        Random random = new Random();

        int maxAnimals = 6;

        foreach (var aviary in _aviaries)
        {
            Animal newAnimal = null;
            string gender;
            int quantityOfAnimals = random.Next(maxAnimals + 1);

            for (int i = 0; i < quantityOfAnimals; i++)
            {
                gender = allGenders[random.Next(allGenders.Count)];
                quantityOfAnimals = random.Next(maxAnimals + 1);

                switch (aviary.Name)
                {
                    case CommandAviaryLions:
                        newAnimal = new Lion(gender);
                        break;

                    case CommandAviaryElephants:
                        newAnimal = new Elefant(gender);
                        break;

                    case CommandAviaryMonkeys:                        
                        newAnimal = new Monkey(gender);
                        break;

                    case CommandAviaryHyenes:
                        newAnimal = new Hyena(gender);
                        break;                       
                   
                }

                if (newAnimal != null)
                    aviary.AddNewAnimal(newAnimal);
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

            if (userInput > 0 && userInput <= _aviaries.Count)
            {
                _aviaries[userInput - 1].ShowInfo();
            }
            else if (userInput == _aviaries.Count + 1)
            {
                isWorking = false;
            }
        }
    }

    private void ShowAviaries()
    {
        for (int i = 0; i < _aviaries.Count; i++)
        {
            Console.WriteLine($"Для выбора вольера \"{_aviaries[i].Name}\" ведите {_aviaries[i].ID} ");
        }

        Console.WriteLine($"Чтобы покинуть зоопарк введите {_aviaries.Count + 1}");
    }
}

class Aviary
{
    private List<Animal> _animals;

    public Aviary(string name, int id)
    {
        Name = name;
        ID = id;
        _animals = new List<Animal>();
    }

    public int ID { get; private set; }
    public string Name { get; private set; }

    public void ShowInfo()
    {
        if (_animals.Count > 0)
        {
            foreach (var animal in _animals)
            {
                animal.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("Вольер пуст!");
        }

        Console.ReadKey();
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