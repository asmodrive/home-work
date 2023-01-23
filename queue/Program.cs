using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumMoney = 0;
            Queue<int> money = new Queue<int>();

            money.Enqueue(300);
            money.Enqueue(2690);
            money.Enqueue(150);
            money.Enqueue(45);
            money.Enqueue(530);
            money.Enqueue(250);

            while (money.Count > 0)
            {
                int basketAmount = money.Dequeue();
                sumMoney += basketAmount;
                Console.WriteLine($"Сумма корзины клиента: {basketAmount}");
                Console.WriteLine($"Текущий баланс счета: {sumMoney}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
