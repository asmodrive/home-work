using System;
using System.Collections.Generic;

namespace Tehcenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();

            carService.StartWork();
        }
    }

    class CarService
    {
        private const string ExitCommand = "exit";
        private const string StartCommand = "start";
        private const string RepairCommand = "repair";
        private const string DenyCommand = "deny";

        private Warehouse _warehouse = new Warehouse();
        private Queue<Car> _cars = new Queue<Car>();
        private int _carsQueueSize = 7;
        private int _totalMoney = 1500;

        public void StartWork()
        {
            bool isWorking = true;
            CreateCars();

            while (isWorking && _cars.Count > 0)
            {
                _warehouse.ShowAvailableDetails();
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
            _warehouse.ShowAvailableDetails();
            Console.WriteLine("Какую деталь вы хотите отремонтировать?");
            string userInput = Console.ReadLine();
            Detail requiredDetail = new Detail(userInput, 0);

            return _warehouse.ReturnFoundedDetail(requiredDetail) == true && car.BrokenDetail.Name == userInput;
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
            Console.WriteLine($"В машине сломалось: {car.BrokenDetail.Name}");
            Console.WriteLine($"Стоимость замены детали с работой {GetRepairPrice(car.BrokenDetail)} рублей.");
        }

        private void ServiceCar()
        {
            _warehouse.ShowAvailableDetails();
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
                Console.WriteLine($"Вы заработали: {GetRepairPrice(car.BrokenDetail)} рублей.");
                _totalMoney += GetRepairPrice(car.BrokenDetail);
            }
            else
            {
                Console.WriteLine("Была установлена неправильная деталь!");
                Console.WriteLine($"Вы возместили ущерб водителю в размере: {GetPenalty(car.BrokenDetail)} рублей.");
                _totalMoney -= GetPenalty(car.BrokenDetail);
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

    class Car
    {
        private List<Detail> _details = new List<Detail>();


        public Car()
        {
            GetBrokenPart();
        }

        public Detail BrokenDetail { get; private set; }

        public void GetBrokenPart()
        {
            Random random = new Random();

            BrokenDetail = _details[random.Next(_details.Count)];
        }
    }

    class Warehouse
    {
        private List<Detail> _details;
        private List<Detail> _generatedDetails = new List<Detail>();

        public Warehouse()
        {
            CreateDetail();
        }

        public List<Detail> CreateDetail()
        {
            _details = new List<Detail>
            {
                new Detail("Мотор дворников", 2000),
                new Detail("Лобовое стекло", 6000),
                new Detail("Генератор", 3000),
                new Detail("Цилиндр сцепления", 5000),
                new Detail("Трос ручника", 2000),
            };

            return _details;
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

        public void ShowInfo()
        {
            Console.WriteLine($"Название детали: {Name}, цена: {Price}.");
        }
    }