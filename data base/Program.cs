using System;
using System.Collections.Generic;
using System.Threading;

namespace data_base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayerCommand = "1";
            const string RemovePlayerCommand = "2";
            const string BanPlayerCommand = "3";
            const string UnbanPlayerCommand = "4";
            const string ShowInfoPlayerCommand = "5";
            const string ExitCommand = "6";

            Database database = new Database();

            bool isWorking = true;
            Console.WriteLine($"Добавить игрока - {AddPlayerCommand},\nудалить игрока - {RemovePlayerCommand},\nзаблокировать игрока - {BanPlayerCommand},\nразблокировать игрока - {UnbanPlayerCommand}\n" +
                $"показать инфо об игроке - {ShowInfoPlayerCommand},\nвыйти из программы - {ExitCommand}.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPlayerCommand:
                        database.AddPlayer();
                        break;

                    case RemovePlayerCommand:
                        database.DeletePlayer();
                        break;

                    case BanPlayerCommand:
                        database.BanPlayer();
                        break;

                    case UnbanPlayerCommand:
                        database.UnbanPlayer();
                        break;

                    case ShowInfoPlayerCommand:
                        database.ShowPlayers();
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
        public Player(string name, int id, float level, bool isBanned)
        {
            Name = name;
            Id = id;
            Level = level;
            IsBanned = isBanned;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }
        public float Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя игрока: {Name},\nайди игрока: {Id},\nуровень игрока: {Level},\nпроверка на блокировку игрока: {IsBanned}.");
        }

        public void Ban()
        {
            IsBanned = true;
        }
        
        public void Unban()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>()
        {
            new Player("ДА", 1, 12, false),
            new Player("ty", 2, 12, false),
            new Player("tt", 3, 12, false),
            new Player("net", 4, 12, false),
        };

        public void AddPlayer()
        {
            bool isBanned = false;
            Console.WriteLine("Введите никнейм игрока:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите айди игрока начиная с единицы:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int idInput);

            Random random = new Random();
            int minLevel = 0;
            int maxLevel = 100;
            int level = random.Next(minLevel, maxLevel);
            
            if (isCorrect == true && IsIdFree(idInput) == true)
            {
                _players.Add(new Player(name, idInput, level, isBanned));
                Console.WriteLine("Игрок добавлен.");
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите id для удаления:");

            if (TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine("Игрок удален.");
            }
            else
            {
                Console.WriteLine("Такого игрока нет.");
            }
        }

        public void BanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.Ban();
                Console.WriteLine("Игрок забанен.");
            }
            else
            {
                Console.WriteLine("Такого игрока нет.");
            }
        }

        public void UnbanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.Unban();
                Console.WriteLine("Игрок разбанен.");
            }
            else
            {
                Console.WriteLine("Такого игрока нет.");
            }
        }

        public void ShowPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowInfo();
            }
        }

        private bool TryGetPlayer(out Player player)
        {
            player = null;

            Console.WriteLine("Введите айди игрока:");
            bool correctInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (correctInput)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (userInput == _players[i].Id)
                    {
                        player = _players[i];
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsIdFree(int id)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
