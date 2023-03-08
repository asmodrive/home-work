using System;

namespace coloda_cart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string TakeNamePlayerCommand = "1";
            const string TakeCardCommand = "2";
            const string ShofCardHandsCommand = "3";
            const string ShowCarPackCommand = "4";
            const string ExitCommand = "5";

            Player player = new Player();

            bool isWorking = true;
            Console.WriteLine($"Введите операцию: {TakeNamePlayerCommand} - установить имя вашему персонажу, {TakeCardCommand} - взять карту, {ShofCardHandsCommand} - показать имеющиеся карты на руках," +
                $" {ShowCarPackCommand} - показать инфо об имеющихся картах в колоде, {ExitCommand} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeNamePlayerCommand:

                        break;
                    case TakeCardCommand:

                        break;
                    case ShofCardHandsCommand:
                        player.ShowInfoCardHand();
                        break;
                    case ShowCarPackCommand:

                        break;
                    case ExitCommand:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        public string Name { get; set; }

        public void ShowInfoCardHand()
        {
            Console.WriteLine($"{Name} на руках имеет карты:");
        }
    }

    class Card
    {
        public string Heart;
        public string Diamond;
        public string Spade;
        public string Club;
    }

    class Pack
    {
        public int CountCard;
    }
}

// массивы достоинств и мастей