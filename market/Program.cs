using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowProduct = "1";
            const string ShowMyProduct = "2";
            const string BuyProduct = "3";
            const string Exit = "4";

            bool isWorking = true;
            Console.WriteLine($"Введите номер операции:\n{ShowProduct} - посмотреть товары в магазине,\n{ShowMyProduct} - посмотреть ваши товар,\n{BuyProduct} - купить товары," +
                $"\n{Exit} - выйти из магазина.");

            while (isWorking)
            {
                switch (Console.ReadLine())
                {
                    case ShowProduct:

                        break;

                    case ShowMyProduct:

                        break;

                    case BuyProduct:

                        break;

                    case Exit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Buyer
    {
        public Buyer()
        {
            SetName();
            SetCapacityBag();
            SetMoney();
        }

        public string Name { get; private set; }
        public int Bag { get; private set; }
        public int Money { get; private set; }

        public void SetName()
        {
            Console.WriteLine("Введите ваше имя:");
            string userInput = Console.ReadLine();
            Name = userInput;
        }

        public void SetCapacityBag()
        {
            int capacity = 0;
            int minValue = 3;
            int maxValue = 15;
            Random random = new Random();
            capacity = random.Next(minValue, maxValue);
            Bag = capacity;
            Console.WriteLine($"Вместимость вашей сумки составляет: {Bag} килограмм.");
        }

        public void SetMoney()
        {
            int money = 0;
            int minValue = 50;
            int maxValue = 600;
            Random random = new Random();
            money = random.Next(minValue, maxValue);
            Money = money;
            Console.WriteLine($"У вас в кошельке: {Money} американских рублей.");
        }
    }

    class Seller
    {
        private List<Product> _products = new List<Product>()
        {
        new Product("хлеб", new DateTime(2023, 07, 15), 1, 150),
        new Product("молоко", new DateTime(2023, 04, 07), 3, 70),
        new Product("пиво", new DateTime(2023, 09, 12), 5, 25),
        new Product("сыр", new DateTime(2023, 02, 05), 3, 450),
        new Product("йогурт", new DateTime(2023, 01, 30), 7, 75),
        new Product("масло", new DateTime(2023, 09, 28), 9, 125),
            };
    }

    class Product
    {
        public Product(string nameProduct, DateTime expirationDate, int weight, int price)
        {
            NameProduct = nameProduct;
            ExpirationDate = expirationDate;
            Weight = weight;
            Price = price;
        }

        public string NameProduct { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {NameProduct},\nсрок годности: {ExpirationDate},\nвес: {Weight},\nцена: {Price}.");
        }
    }
}

//проверка на срок годности по отношению к текущему времени в сишарп