using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace aqvarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandExit = "3";

            bool isWorking = true;
            Aquarium aquarium = new Aquarium(15);

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandAddFish} - добавить рыбу в аквариум,\n{CommandRemoveFish} - убрать рыбу из аквариума,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;

                    case CommandRemoveFish:
                        aquarium.DeleteFish();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        break;
                }

                aquarium.DeleteDeadFish();
                aquarium.ShowFishes();
                aquarium.IncreaseFishAge();
            }
        }
    }
}

class Aquarium
{
    private List<Fish> _fishes = new List<Fish>();

    public Aquarium(int maxCount)
    {
        MaxCount = maxCount;
    }

    public int MaxCount { get; private set; } = 15;

    public void ShowFishes()
    {
        int numberFish = 1;
        Console.WriteLine("Список рыб:");

        foreach (var fish in _fishes)
        {
            Console.WriteLine($"Номер: {numberFish}, имя: {fish.Name}, возраст: {fish.Age}, максимальный возраст: {fish.MaxAge}");
            numberFish++;
        }
    }

    public void AddFish()
    {
        Console.WriteLine("Введите имя рыбы:");
        string userInput = Console.ReadLine();
        Console.WriteLine("Введите возраст:");
        string inputAge = Console.ReadLine();
        bool isCorrect = int.TryParse(inputAge, out int age);

        if (isCorrect && _fishes.Count <= MaxCount)
        {
            Console.WriteLine("Рыба добавлена.");
            _fishes.Add(new Fish(age, userInput));
        }
        else if (isCorrect == false)
        {
            Console.WriteLine("Попробуйте еще раз.");
        }
    }

    public void DeleteFish()
    {
        Fish fish;

        if (TryGetFish(out fish))
        {
            _fishes.Remove(fish);
        }
    }

    public void DeleteDeadFish()
    {
        for (int i = 0; i < _fishes.Count; i++)
        {
            if (_fishes[i].Age >= _fishes[i].MaxAge)
            {
                _fishes.Remove(_fishes[i]);
                i--;
            }
        }
    }

    private bool TryGetFish(out Fish fish)
    {
        Console.WriteLine("Введите номер рыбы:");
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userInput);

        if (userInput - 1 < _fishes.Count && userInput > 0)
        {
            fish = _fishes[userInput - 1];
            Console.WriteLine("Вы достали рыбу.");
            return true;
        }
        else if (isCorrect == false)
        {
            Console.WriteLine("Попробуйте еще раз.");
            fish = null;
            return false;
        }
        else
        {
            Console.WriteLine("В аквариуме нет рыбы с таким номером.");
            fish = null;
            return false;
        }
    }

    public void IncreaseFishAge()
    {
        foreach (var fish in _fishes)
        {
            fish.Live();
        }
    }
}

class Fish
{
    public Fish(int age, string name)
    {
        var random = new Random();
        Age = age;
        Name = name;
        MaxAge = random.Next(20, 70);
    }

    public int Age { get; private set; }
    public string Name { get; private set; }
    public int MaxAge { get; private set; }

    public void Live()
    {
        Age++;
    }
}