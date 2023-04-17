using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowProduct = "1";
            const string CommandShowMyProduct = "2";
            const string CommandBuyProduct = "3";
            const string CommandCurrentSeller = "4";
            const string CommandExit = "5";

            string name = string.Empty;

            List<Product> products = new List<Product>();
            Buyer buyer = new Buyer();
            MarketPlace marketPlace = new MarketPlace();
            marketPlace.SetCurrentSeller();

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandShowProduct} - посмотреть товары в магазине,\n{CommandShowMyProduct} - посмотреть ваши товар,\n{CommandBuyProduct} - купить товары," +
                    $"\n{CommandCurrentSeller} - вернуться к выбору продавца,\n{CommandExit} - выйти из магазина.");

                switch (Console.ReadLine())
                {
                    case CommandShowProduct:
                        marketPlace.CurrentSeller.ShowProduct();
                        break;

                    case CommandShowMyProduct:
                        buyer.ShowProduct();
                        break;

                    case CommandBuyProduct:
                        marketPlace.BuyProduct(buyer);
                        break;

                    case CommandCurrentSeller:
                        marketPlace.SetCurrentSeller();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class MarketPlace
    {
        private string _currentSeller { get; set; }

        private Dictionary<string, Seller> _sellers = new Dictionary<string, Seller>()
        {

            ["Ыван"] = new Seller("продукты", new List<Product>()
            {

                new Product("хлеб", new DateTime(2023, 07, 15), 1, 150),
                new Product("Молоко", new DateTime(2023, 04, 07), 3, 70),
                new Product("пиво", new DateTime(2023, 09, 12), 5, 25),
                new Product("сыр", new DateTime(2023, 02, 05), 3, 450),
                new Product("йогурт", new DateTime(2023, 01, 30), 7, 75),
                new Product("масло", new DateTime(2023, 09, 28), 9, 125)
                }),

            ["НеЫван"] = new Seller("электроника", new List<Product>
            {
                new Product("Телефон", new DateTime(2030, 01, 01), 4, 2500),
                new Product("Планшет", new DateTime(2020, 12, 05), 7, 3400),
                new Product("Компьютер", new DateTime(2004, 01, 21), 15, 12110),
                new Product("Наушники", new DateTime(2029, 09, 01), 1, 250),
                new Product("Монитор", new DateTime(2034, 05, 11), 8, 5000)
                }),

            ["Ывандва"] = new Seller("Обувь", new List<Product>
            {
                new Product("Кроссовки", new DateTime(2030, 01, 01), 3, 1500),
                new Product("Сандали", new DateTime(2020, 12, 05), 2, 560),
                new Product("Сапоги", new DateTime(2004, 01, 21), 5, 1200),
                new Product("Валенки", new DateTime(2029, 09, 01), 1, 50),
                new Product("Подкрадуля", new DateTime(2034, 05, 11), 50, 99999)
            })

        };

        public Seller CurrentSeller => (string.IsNullOrEmpty(_currentSeller) == false && _sellers.Count > 0) ? _sellers[_currentSeller] : null;

        public void BuyProduct(Buyer buyer)
        {
            Console.WriteLine("Выберите продукт который хотите купить:");
            string userInput = Console.ReadLine();
            var internalProduct = CurrentSeller.TryGetProduct(userInput);

            if (internalProduct != null)
            {
                if (buyer.CanBuyProduct(internalProduct))
                {
                    buyer.BuyProduct(internalProduct);
                    CurrentSeller.RemoveProduct(internalProduct);
                    Console.WriteLine($"Вы купили:{internalProduct.NameProduct}");
                }
            }
            else
            {
                Console.WriteLine($"Нет такого продукта, {userInput}");
            }
        }

        public void ShowSellers()
        {
            foreach (var seller in _sellers)
            {
                Console.WriteLine($"Имя продавца: {seller.Key}, тип товаров: {seller.Value.ProductsType}.");
            }
        }

        public void SetCurrentSeller()
        {
            Console.WriteLine("Выберите продавца:");
            ShowSellers();
            string userInput = Console.ReadLine();

            if (_sellers.ContainsKey(userInput))
            {
                _currentSeller = userInput;
            }
            else
            {
                Console.WriteLine("Нет такого продавца.");
            }
        }
    }

    class Buyer : Character
    {
        public Buyer()
        {
            SetName();
            SetCapacityBag();
            SetMoney();
            _products = new List<Product>();
        }

        public int Bag { get; private set; }

        public void SetName()
        {
            Console.WriteLine("Введите ваше имя:");
            string userInput = Console.ReadLine();
            Name = userInput;
        }

        public void SetCapacityBag()
        {
            int capacity = 0;
            int minValue = 12;
            int maxValue = 24;
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

        public bool CanBuyProduct(Product product)
        {
            if (Bag < product.Weight)
            {
                Console.WriteLine("В вашей сумке совсем нет места");
                return false;
            }

            if (Money < product.Price)
            {
                Console.WriteLine("В вашем кошельке совсем нет грошей");
                return false;
            }

            return true;
        }

        public void BuyProduct(Product product)
        {
            Bag -= product.Weight;
            Money -= product.Price;

            if (product.ExpirationDate < DateTime.Now)
            {
                Console.WriteLine("Вы купили просрочку, деньги вам не вернут.");
            }

            _products.Add(product);
        }

        public void GetMoney(Product product)
        {
            ChangeMoneyQuantity(product.Price);
        }
    }

    class Seller : Character
    {
        public Seller(string productsType, List<Product> products)
        {
            ProductsType = productsType;
            _products = products;
        }

        public string ProductsType { get; private set; }

        public Product TryGetProduct(string userInput)
        {
            foreach (Product product in _products)
            {
                if (product.NameProduct == userInput)
                    return product;
            }

            return null;
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public void GetMoney(Product product)
        {
            ChangeMoneyQuantity(product.Price);
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

    class Character
    {
        public List<Product> _products = new List<Product>();

        public string Name;
        public int Money;

        public void ShowProduct()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }

        public void ChangeMoneyQuantity(int difference)
        {
            Money += difference;
        }
    }
}