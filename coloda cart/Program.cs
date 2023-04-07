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
            const string ShofNamePlayer = "2";
            const string TakeCardCommand = "3";
            const string ShofCardHandsCommand = "4";
            const string ShowCarPackCommand = "5";
            const string ResetPack = "6";
            const string ExitCommand = "7";

            string name = string.Empty;
            string mast = string.Empty;
            string advantage = string.Empty;

            Player player = new Player(name);
            Pack pack = new Pack();
            pack.ResetPack();

            Console.OutputEncoding = Encoding.UTF8;
            bool isWorking = true;
            Console.WriteLine($"Введите операцию:\n {TakeNamePlayerCommand} - установить имя вашему персонажу,\n {ShofNamePlayer} - показать имя персонажа, \n {TakeCardCommand} - взять карту," +
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

                    case ShofNamePlayer:
                        player.ShowName();
                        break;

                    case TakeCardCommand:
                        if (pack.CurrentPackCount() > 0)
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
                        pack.ResetPack();
                        player.ResetPlayerCards();
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
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        private List<Card> _playerCards = new List<Card>();

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

        public void ShowName()
        {
            Console.WriteLine(Name);
        }

        public void AddCardToHand(Card card)
        {
            _playerCards.Add(card);
            Console.WriteLine($"Вы взяли карту: {card.Mast} {card.Advantage}");
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
        private List<string> _mast = new List<string>()
        {
             ("♦️"),
             ("♥️"),
             ("♧"),
             ("♤")
        };

        private List<string> _advantage = new List<string>()
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

        private List<Card> _cards;

        public void ResetPack()
        {
            _cards = FullPack();
        }

        public List<Card> FullPack()
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < _mast.Count; i++)
            {
                for (int j = 0; j < _advantage.Count; j++)
                {
                    cards.Add(new Card(_mast[i], _advantage[j]));
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

        public int CurrentPackCount()
        {
            return _cards.Count;
        }
    }
}