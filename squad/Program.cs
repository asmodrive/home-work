using System;
using System.Collections.Generic;

namespace Автомагазин
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.Start();
        }
    }

    class Detail
    {
        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }

    class Car
    {
        private static Random _random = new Random();
        private List<Detail> _details = new List<Detail>();

        public Car()
        {
            CreateDetailsList();
            CreateBrokenPart();
        }

        public Detail BrokenPart { get; private set; }

        private void CreateDetailsList()
        {
            _details.Add(new Detail("Двигатель", 5000));
            _details.Add(new Detail("Лобовое стекло", 1000));
            _details.Add(new Detail("Аудиосистема", 800));
            _details.Add(new Detail("Фара", 500));
            _details.Add(new Detail("Колесо", 1000));
            _details.Add(new Detail("Бампер", 300));
            _details.Add(new Detail("Сигнализация", 2000));
        }

        private void CreateBrokenPart()
        {
            BrokenPart = _details[_random.Next(_details.Count)];
        }
    }

    class Storage
    {
        private List<Detail> _allDetailTypes = new List<Detail>();
        private List<Detail> _generatedDetails = new List<Detail>();
        private Random _random = new Random();
        private int _size = 15;

        public Storage()
        {
            Fill();
        }

        public bool ReturnFoundedDetail(Detail requiredDetail)
        {
            if (IsDetailFounded(requiredDetail) == true)
            {
                _generatedDetails.Remove(requiredDetail);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAvailableDetails()
        {
            Console.WriteLine("На складе остались следующие детали:");

            foreach (Detail detail in _generatedDetails)
            {
                Console.WriteLine($"Деталь - {detail.Name}, цена - {detail.Price}");
            }
        }

        private void Fill()
        {
            CreateDetailsList();

            for (int i = 0; i < _size; i++)
            {
                _generatedDetails.Add(_allDetailTypes[_random.Next(_allDetailTypes.Count)]);
            }
        }

        private void CreateDetailsList()
        {
            _allDetailTypes.Add(new Detail("Двигатель", 5000));
            _allDetailTypes.Add(new Detail("Лобовое стекло", 1000));
            _allDetailTypes.Add(new Detail("Аудиосистема", 800));
            _allDetailTypes.Add(new Detail("Фара", 500));
            _allDetailTypes.Add(new Detail("Колесо", 1000));
            _allDetailTypes.Add(new Detail("Бампер", 300));
            _allDetailTypes.Add(new Detail("Сигнализация", 2000));
        }

        private bool IsDetailFounded(Detail requiredDetail)
        {
            foreach (Detail detail in _generatedDetails)
            {
                if (requiredDetail.Name == detail.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class CarService
    {
        private const string ExitCommand = "exit";
        private const string StartCommand = "start";
        private const string RepairCommand = "repair";
        private const string DenyCommand = "deny";

        private Storage _storage = new Storage();
        private Queue<Car> _cars = new Queue<Car>();
        private int _carsQueueSize = 7;
        private int _totalMoney = 1500;

        public void Start()
        {
            bool isWorking = true;
            CreateCars();

            while (isWorking && _cars.Count > 0)
            {
                _storage.ShowAvailableDetails();
                Console.WriteLine();
                Console.WriteLine($"На балансе автосервиса {_totalMoney} рублей.\n");
                Console.WriteLine($"В очереди на ремонт стоят {_cars.Count} машин.\n");
                Console.WriteLine($"{StartCommand} - начать работу автосервиса\n" +
                    $"{ExitCommand} - завершить работу автосервиса");
                Console.WriteLine("Ваш выбор: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case StartCommand:
                        ServiceCar();
                        break;
                    case ExitCommand:
                        isWorking = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка при вводе!\n");
                        break;
                }
            }
        }

        private int GetRepairPrice(Detail brokenPart)
        {
            int totalRepairPrice = 0;
            int serviceCost = 300;
            totalRepairPrice += brokenPart.Price + serviceCost;

            return totalRepairPrice;
        }

        private int GetPenalty(Detail brokenPart)
        {
            return brokenPart.Price;
        }

        private bool TryToRepair(Car car)
        {
            _storage.ShowAvailableDetails();
            Console.WriteLine("Какую деталь вы хотите отремонтировать?");
            string userInput = Console.ReadLine();
            Detail requiredDetail = new Detail(userInput, 0);

            return _storage.ReturnFoundedDetail(requiredDetail) == true && car.BrokenPart.Name == userInput;
        }

        private void CreateCars()
        {
            for (int i = 0; i < _carsQueueSize; i++)
            {
                _cars.Enqueue(new Car());
            }
        }

        private void ShowBrokenPart(Car car)
        {
            Console.WriteLine($"В машине сломалось: {car.BrokenPart.Name}");
            Console.WriteLine($"Стоимость замены детали с работой {GetRepairPrice(car.BrokenPart)} рублей.");
        }

        private void ServiceCar()
        {
            _storage.ShowAvailableDetails();
            Console.WriteLine();
            Car currentCar = _cars.Dequeue();
            ShowBrokenPart(currentCar);
            Console.WriteLine();
            Console.WriteLine($"{RepairCommand} - отремонтировать машину\n{DenyCommand} - отказать в ремонте\nЧто будем делать:");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case RepairCommand:
                    RepairCar(currentCar);
                    break;
                case DenyCommand:
                    DenyRepair();
                    break;
                default:
                    Console.WriteLine("Ошибка при вводе!");
                    DenyRepair();
                    break;
            }
        }

        private void RepairCar(Car car)
        {
            Console.Clear();

            if (TryToRepair(car))
            {
                Console.WriteLine("Автомобиль отромонтирован успешно!");
                Console.WriteLine($"Вы заработали: {GetRepairPrice(car.BrokenPart)} рублей.");
                _totalMoney += GetRepairPrice(car.BrokenPart);
            }
            else
            {
                Console.WriteLine("Была установлена неправильная деталь!");
                Console.WriteLine($"Вы возместили ущерб водителю в размере: {GetPenalty(car.BrokenPart)} рублей.");
                _totalMoney -= GetPenalty(car.BrokenPart);
            }
        }

        private void DenyRepair()
        {
            int fine = 300;
            Console.Clear();
            Console.WriteLine($"Вы не отремонтировали машину, с вас списан штраф в размере {fine} рублей!\n");
            _totalMoney -= fine;
        }
    }
}