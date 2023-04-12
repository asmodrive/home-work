using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowProduct = "1";
            const string CommandShowMyProduct = "2";
            const string CommandBuyProduct = "3";
            const string CommandExit = "4";

            Buyer buyer = new Buyer();
            Seller seller = new Seller();

            bool isWorking = true;
            Console.WriteLine($"Введите номер операции:\n{CommandShowProduct} - посмотреть товары в магазине,\n{CommandShowMyProduct} - посмотреть ваши товар,\n{CommandBuyProduct} - купить товары," +
                $"\n{CommandExit} - выйти из магазина.");

            while (isWorking)
            {
                switch (Console.ReadLine())
                {
                    case CommandShowProduct:
                        seller.ShowProduct();
                        break;

                    case CommandShowMyProduct:

                        break;

                    case CommandBuyProduct:
                        seller.ShowMarket();
                        break;

                    case CommandExit:
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

        private List<Product> _products;

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

        public void ShowMyProduct()
        {

        }

        public void TakeCardToHand(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"");
        }
    }

    class Seller
    {
        private List<Product> _products = new List<Product>()
        {
        new Product("хлеб", new DateTime(2023, 07, 15), 1, 150),
        new Product("Молоко", new DateTime(2023, 04, 07), 3, 70),
        new Product("пиво", new DateTime(2023, 09, 12), 5, 25),
        new Product("сыр", new DateTime(2023, 02, 05), 3, 450),
        new Product("йогурт", new DateTime(2023, 01, 30), 7, 75),
        new Product("масло", new DateTime(2023, 09, 28), 9, 125),
            };

        public void ShowProduct()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }

        private void BuyProduct()
        {
            if (TryGetProduct(out Product product))
            {

            }
        }

        public void ShowMarket()
        {
            const string CommandShowProduct = "1";
            const string CommandBuyProduct = "2";

            Console.WriteLine($"Выберите хотите ли вы увидеть список продуктов или перейти к покупкам:\n{CommandShowProduct} - показать список,\n{CommandBuyProduct} - перейти к покупкам.");

            switch (Console.ReadLine())
            {
                case CommandShowProduct:
                    ShowProduct();
                    break;

                case CommandBuyProduct:
                    BuyProduct();
                    break;
            }
        }

        private bool TryGetProduct(out Product product)
        {
            Console.WriteLine("Введите название продукта:");
            string userInput = Console.ReadLine();
            product = null;

            for (int i = 0; i < _products.Count; i++)
            {
                if (userInput == _products[i].NameProduct)
                {
                    product = _products[i];
                    return true;
                }
            }

            return false;
        }

       
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