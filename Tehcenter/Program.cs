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
        private Queue<Car> _cars = new Queue<Car>();
        private Warehouse _storage = new Warehouse();
        private int _money;

        public void StartWork()
        {
            const string CommandRepairCars = "1";
            const string CommandExit = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandRepairCars} - заняться ремонтом,\n{CommandExit} - выйти из программы. ");

                switch (Console.ReadLine())
                {
                    case CommandRepairCars:
                        ServiceCar();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        public void ServiceCar()
        {
            const string CommandRepairCar = "1";
            const string CommandDeny = "2";


            int cost = 5000;

            Console.WriteLine($"Выберите номер операции:\n{CommandRepairCar} - починить авто,\n{CommandDeny} - отказать в обслуживании.");

            switch (Console.ReadLine())
            {
                case CommandRepairCar:

                    break;

                case CommandDeny:
                    Console.WriteLine($"За отказ в обслуживании с вас будет взыскано {cost} дублонов.");
                    PayExpenses(cost);
                    break;
            }
        }

        public void PayExpenses(int cost)
        {
            _money -= cost;
            Console.WriteLine($"С баланса автосервиса взыскано: {cost} американских рублей, баланс сервиса составляет: {_money}");
        }

        private void RepairCar(Car car)
        {
            int cost = 10000;

            if (_money > 0)
            {
                Console.WriteLine("Автомобиль отромонтирован успешно!");
            }
            else
            {
                Console.WriteLine($"За ошибки в ремонте вы будете оштрафованы на {cost} бачей.");
                PayExpenses(cost);
            }
        }

        private int GetRepairPrice(Detail brokenPart)
        {
            int repairPrice = 0;
            int workRatio = 500;
            repairPrice += brokenPart.Price + workRatio;

            return repairPrice;
        }

        private bool TryToRepair(Car car)
        {
            _storage.ShowAvailableDetails();
            Console.WriteLine("Какую деталь вы хотите отремонтировать?");
            string userInput = Console.ReadLine();
            Detail requiredDetail = new Detail(userInput, 0);

            return _storage.ReturnFoundedDetail(requiredDetail) == true && car.BrokenDetail.Name == userInput;
        }
    }

    class Car
    {
        private List<Detail> _details;


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
}