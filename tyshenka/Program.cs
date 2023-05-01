using System;
using System.Collections.Generic;
using System.Linq;

namespace tyshenka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.StartWork();
        }
    }

    class DataBase
    {
        private List<Stew> _stews;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandGetStew = "1";
            const string CommandExit = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandGetStew} - получить список просроченной тушенки,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandGetStew:
                        GetExpiredStew();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private void GetExpiredStew()
        {
            var foundStew = _stews.Where(stew => stew.ExpirationDate < DateTime.Now);

            foreach (var stew in foundStew)
            {
                stew.ShowInfo();
            }
        }

        private List<Stew> Create()
        {
            _stews = new List<Stew>
            {
                new Stew("Говядина", new DateTime(2004, 01, 01), new DateTime(2014, 01, 01) ),
                new Stew("Свинина", new DateTime(2020, 01, 01), new DateTime(2025, 01, 01) ),
                new Stew("Баранина", new DateTime(1984, 01, 01), new DateTime(2005, 01, 01) ),
                new Stew("Индейка", new DateTime(1790, 01, 01), new DateTime(1810, 01, 01) ),
                new Stew("Лосина", new DateTime(2005, 01, 01), new DateTime(2015, 01, 01) ),
                new Stew("Тунец", new DateTime(2012, 01, 01), new DateTime(2025, 01, 01) ),
                new Stew("Шпроты", new DateTime(2023, 01, 01), new DateTime(2040, 01, 01) ),
                new Stew("Карп", new DateTime(2021, 01, 01), new DateTime(2030, 01, 01) ),
                new Stew("Цыпленок", new DateTime(1993, 01, 01), new DateTime(2020, 01, 01) ),
                new Stew("Конина", new DateTime(1999, 01, 01), new DateTime(2021, 01, 01) )
            };

            return _stews;
        }
    }

    class Stew
    {
        public Stew(string title, DateTime productionDate, DateTime expirationDate)
        {
            Title = title;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

        public string Title { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Title}, дата производства: {ProductionDate}, срок годности: {ExpirationDate}.");
        }
    }
}