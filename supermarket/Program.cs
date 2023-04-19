using System;
using System.Collections.Generic;

namespace supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }

    class Supermarket
    {
        private List<Product> _products;
        Queue<Buyer> _buyers = new Queue<Buyer>();

        public Supermarket()
        {
            FillProducts();
        }

        public void OpenStore()
        {
            int numberBuyer = 1;
            CreateBuyers();

            while(_buyers.Count > 0)
            {
                Buyer buyer = _buyers.Peek();
                Console.WriteLine($"В очереди стоит: {_buyers.Count} покупателей.");
                buyer.ShowInfo(numberBuyer);
            }
        }

        private void FillProducts()
        {
            _products = new List<Product>()
            {
                new Product("Пиво", 25),
                new Product("Чипсы", 40),
                new Product("Кефир", 85),
                new Product("Сыр", 150),
                new Product("Вода", 40),
                new Product("Пельмени", 120),
                new Product("Блины", 50),
                new Product("Колбаса", 100),
            };
        }

        private void CreateBuyers()
        {
            int buyerInQueue = 7;

            for (int i = 0; i < buyerInQueue; i++)
                _buyers.Enqueue(new Buyer(_products));
        }

        private void CanBuyProduct(Buyer buyer, ref int numberBuyer)
        {
            
        }
    }


    class Buyer
    {
        private static Random _random = new Random();
        private List<Product> _products = new List<Product>();

        public Buyer(List<Product> products)
        {
            FillCart(products);
        }

        public int SumBuy { get; private set; }
        public int Money { get; private set; }
        public int PoructsCount => _products.Count;

        public void RemoveRandomProduct()
        {
            int indexRemoveProduct = _random.Next(_products.Count);
            Console.WriteLine($"Убрали {_products[indexRemoveProduct].Name}");
            SumBuy -= _products[indexRemoveProduct].Price;
            _products.RemoveAt(indexRemoveProduct);
        }

        public void ShowInfo(int number)
        {
            Console.Write($"{number}-й клиент. Денег: {Money}\nКорзина: ");

            for (int i = 0; i < _products.Count; i++)
                Console.WriteLine($"{_products[i].Name} - {_products[i].Price} руб");

            Console.WriteLine();
        }

        private void FillCart(List<Product> products)
        {
            int maxCountMoney = 750;
            Money = _random.Next(maxCountMoney);

            int countProductsInCart = _random.Next(1, products.Count);

            for (int i = 0; i < countProductsInCart; i++)
            {
                int indexProduct = _random.Next(products.Count);
                _products.Add(products[indexProduct]);
                SumBuy += products[indexProduct].Price;
            }
        }
    }
    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Продукт: {Name}, цена: {Price}.");
        }
    }
}
