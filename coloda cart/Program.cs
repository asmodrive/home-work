using System;
using System.Collections.Generic;
using System.Text;

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
            const string ResetPack = "5";
            const string ExitCommand = "6";

            string name = string.Empty;
            string mast = string.Empty;
            string advantage = string.Empty;

            Player player = new Player();
            Pack pack = new Pack();
            pack.ResetDeck();

            Console.OutputEncoding = Encoding.UTF8;
            bool isWorking = true;
            Console.WriteLine($"Введите операцию:\n {TakeNamePlayerCommand} - установить имя вашему персонажу, \n {TakeCardCommand} - взять карту," +
                $"\n {ShofCardHandsCommand} - показать имеющиеся карты на руках,\n {ShowCarPackCommand} - показать инфо об имеющихся картах в колоде,\n {ResetPack} - сдать заново колоду, " +
                $"\n {ExitCommand} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeNamePlayerCommand:
                        player.SetName();
                        break;

                    case TakeCardCommand:
                        if (pack.CurrentDeckCount() > 0)
                        {
                            var card = pack.TakeCard();
                            player.AddCardToHand(card);
                        }
                        else
                        {
                            Console.WriteLine("В колоде больше нет карт.");
                        }
                        break;

                    case ShofCardHandsCommand:
                        player.ShowInfoCardHand();
                        break;

                    case ShowCarPackCommand:
                        pack.ShowCards();
                        break;

                    case ResetPack:
                        pack.ResetDeck();
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

        public void AddCardToHand(Card card)
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

        public string Mast;
        public string Advantage;
    }

    class Pack
    {
        Player _player;
        private List<Card> _cards = new List<Card>();

        public void ResetDeck()
        {
            _player.ResetPlayerCards();
            _cards = FillDeck();
        }

        public List<Card> FillDeck()
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

        public Card TakeCard()
        {
            int maxValue = _cards.Count;
            int minValue = 0;
            Random random = new Random();
            var card = _cards[random.Next(minValue, maxValue)];
            _cards.Remove(card);
            return card;
        }

        public int CurrentDeckCount()
        {
            return _cards.Count;
        }
    }
}