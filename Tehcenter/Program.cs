using System;
using System.Collections.Generic;

namespace Tehcenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    class Service
    {
        private Warehouse _warehouse = new Warehouse();
        private Queue<Car> _cars = new Queue<Car>();
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
                detail.ShowInfo();
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