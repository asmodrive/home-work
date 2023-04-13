using System;
using System.Collections.Generic;

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
                        buyer.ShowMyProduct();
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
        private Dictionary<string, Seller> _sellers = new Dictionary<string, Seller>()
        {

            ["Ыван"] = new Seller("продукты", new List<Product>()
            {

                new Product("хлеб", 1, new DateTime(2023, 07, 15), 1, 150),
                new Product("Молоко", 2, new DateTime(2023, 04, 07), 3, 70),
                new Product("пиво", 3, new DateTime(2023, 09, 12), 5, 25),
                new Product("сыр", 4, new DateTime(2023, 02, 05), 3, 450),
                new Product("йогурт", 5, new DateTime(2023, 01, 30), 7, 75),
                new Product("масло", 6, new DateTime(2023, 09, 28), 9, 125)
                }),

            ["НеЫван"] = new Seller("электроника", new List<Product>
            {
                new Product("Телефон", 7, new DateTime(2030, 01, 01), 4, 2500),
                new Product("Планшет", 8, new DateTime(2020, 12, 05), 7, 3400),
                new Product("Компьютер", 9, new DateTime(2004, 01, 21), 15, 12110),
                new Product("Наушники", 10, new DateTime(2029, 09, 01), 1, 250),
                new Product("Монитор", 11, new DateTime(2034, 05, 11), 8, 5000)
                }),

            ["Ывандва"] = new Seller("Обувь", new List<Product>
            {
                new Product("Кроссовки", 12, new DateTime(2030, 01, 01), 3, 1500),
                new Product("Сандали", 13, new DateTime(2020, 12, 05), 2, 560),
                new Product("Сапоги", 14, new DateTime(2004, 01, 21), 5, 1200),
                new Product("Валенки", 15, new DateTime(2029, 09, 01), 1, 50),
                new Product("Подкрадуля", 16, new DateTime(2034, 05, 11), 50, 99999)
            })

        };

        private string _currentSeller { get; set; }
        public Seller CurrentSeller => (!string.IsNullOrEmpty(_currentSeller) && _sellers.Count > 0) ? _sellers[_currentSeller] : null;

        public void BuyProduct(Buyer buyer)
        {
            Console.WriteLine("Выберите продукт который хотите купить:");
            string userInput = Console.ReadLine();
            var internalProduct = CurrentSeller.GetProduct(userInput);

            if (internalProduct != null)
            {
                if (buyer.CheckBuyProduct(internalProduct))
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

    class Buyer
    {
        public Buyer()
        {
            SetName();
            SetCapacityBag();
            SetMoney();
            _products = new List<Product>();
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

        public void ShowMyProduct()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Ваша котомка совсем пуста");
            }
            else
            {
                foreach (Product product in _products)
                {
                    Console.WriteLine($"{Name} имеет в корзине: {product.NameProduct}");
                }
            }
        }

        public bool CheckBuyProduct(Product product)
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
    }

    class Seller
    {
        private List<Product> _products = new List<Product>()
        {
        };

        public Seller(string productsType, List<Product> products)
        {
            ProductsType = productsType;
            _products = products;
        }

        public string ProductsType { get; private set; }

        public void ShowProduct()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }

        public Product GetProduct(string userInput)
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
    }

    class Product
    {
        public Product(string nameProduct, int numberProduct, DateTime expirationDate, int weight, int price)
        {
            NameProduct = nameProduct;
            NumberProduct = numberProduct;
            ExpirationDate = expirationDate;
            Weight = weight;
            Price = price;
        }

        public string NameProduct { get; private set; }
        public int NumberProduct { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {NameProduct},\nсрок годности: {ExpirationDate},\nвес: {Weight},\nцена: {Price}.");
        }
    }
}