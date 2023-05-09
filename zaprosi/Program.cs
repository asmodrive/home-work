using System;
using System.Collections.Generic;
using System.Linq;

namespace zaprosi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase data = new DataBase();

            data.StartWork();
        }
    }

    class DataBase
    {
        private List<Player> _players;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandLevelOutput = "1";
            const string CommandPowerOutput = "2";
            const string CommandExit = "3";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции:\n{CommandLevelOutput} - вывод топ 3 по уровню,\n{CommandPowerOutput} - вывод топ 3 по силе,\n{CommandExit} - выход из программы.");

                switch (Console.ReadLine())
                {
                    case CommandLevelOutput:
                        SortingPlayerLevel();
                        break;

                    case CommandPowerOutput:
                        SortingPlayerPower();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private List<Player> Create()
        {
            _players = new List<Player>
            {
                new Player("Зубенко Михаил Петрович", 5, 10),
                new Player("Чарльз Мэнсон", 48, 34),
                new Player("Пабло Эскобак", 54, 12),
                new Player("Джек-потрошитель", 140, 59),
                new Player("Дик Турпин", 89, 123),
                new Player("Чарльз Бронсон", 14, 543),
                new Player("Собачка Квака", 8, 983),
                new Player("Джейсон Стэтхем", 38, 123),
                new Player("Ник Ковач", 53, 4378),
                new Player("Джек Хантер", 1432, 123)
            };

            return _players;
        }

        private void SortingPlayerLevel()
        {
            int quantityPlayers = 3;

            _players = _players.OrderByDescending(player => player.Level).Take(quantityPlayers).ToList();

            ShowPlayersInfo(_players);
        }

        private void SortingPlayerPower()
        {
            int quantityPlayers = 3;

            _players = _players.OrderByDescending(player => player.Power).Take(quantityPlayers).ToList();

            ShowPlayersInfo(_players);
        }

        private void ShowPlayersInfo(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                players[i].ShowInfo();
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, уровень: {Level}, сила: {Power}.");
        }
    }
}
