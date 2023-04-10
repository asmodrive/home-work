using System;
using System.Collections.Generic;
using System.Text;

namespace coloda_cart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string TakeCardCommand = "1";
            const string ShofCardHandsCommand = "2";
            const string ShowCarPackCommand = "3";
            const string ResetPack = "4";
            const string ExitCommand = "5";

            Player player = new Player();
            Pack pack = new Pack();
            pack.Reset();

            Console.OutputEncoding = Encoding.UTF8;
            bool isWorking = true;
            Console.WriteLine($"Введите операцию:\n {TakeCardCommand} - взять карту," +
                $"\n {ShofCardHandsCommand} - показать имеющиеся карты на руках,\n {ShowCarPackCommand} - показать инфо об имеющихся картах в колоде,\n {ResetPack} - сдать заново колоду, " +
                $"\n {ExitCommand} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeCardCommand:
                        player.TakeCardToHand(pack.GetCard());
                        break;

                    case ShofCardHandsCommand:
                        player.ShowInfoCardHand();
                        break;

                    case ShowCarPackCommand:
                        pack.ShowCards();
                        break;

                    case ResetPack:
                        player.ResetPlayerCards();
                        pack.Reset();
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
        private List<Card> _playerCards = new List<Card>();

        public Player()
        {
            SetName();
        }

        public string Name { get; private set; }


        public void ShowInfoCardHand()
        {
            Console.WriteLine($"{Name} на руках имеет карты:");

            foreach (Card card in _playerCards)
            {
                Console.WriteLine(card.Mast + card.Advantage);
            }
        }

        public void SetName()
        {
            Console.WriteLine("Введите имя персонажа:");
            string userInput = Console.ReadLine();
            Name = userInput;
        }

        public void TakeCardToHand(Card card)
        {
            _playerCards.Add(card);
            Console.WriteLine($"{Name} взял карту: {card.Mast} {card.Advantage}");
        }

        public void ResetPlayerCards()
        {
            _playerCards.Clear();
        }
    }

    class Card
    {
        public Card(string mast, string advantage)
        {
            Mast = mast;
            Advantage = advantage;
        }

        public string Mast { get; private set; }
        public string Advantage { get; private set; }
    }

    class Pack
    {
        private List<Card> _cards = new List<Card>();

        public void Reset()
        {
            _cards = Fill();
        }

        private List<Card> Fill()
        {
            List<string> mast = new List<string>()
        {
             ("♦️"),
             ("♥️"),
             ("♧"),
             ("♤")
        };

            List<string> advantage = new List<string>()
        {
            ("6"),
            ("7"),
            ("8"),
            ("9"),
            ("10"),
            ("J"),
            ("Q"),
            ("K"),
            ("A")
        };

            _cards.Clear();

            List<Card> cards = new List<Card>();

            for (int i = 0; i < mast.Count; i++)
            {
                for (int j = 0; j < advantage.Count; j++)
                {
                    cards.Add(new Card(mast[i], advantage[j]));
                }
            }

            return cards;
        }

        public void ShowCards()
        {
            foreach (Card card in _cards)
            {
                Console.WriteLine($"{card.Mast} {card.Advantage}");
            }
        }

        public Card GetCard()
        {
            int maxValue = _cards.Count;
            int minValue = 0;
            Random random = new Random();
            var card = _cards[random.Next(minValue, maxValue)];
            _cards.Remove(card);
            return card;
        }

        public int CurrentCount()
        {
            return _cards.Count;
        }
    }
}