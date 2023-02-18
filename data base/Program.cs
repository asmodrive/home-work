using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Xml.Linq;

namespace data_base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddPlayer = "1";
            const string RemovePlayer = "2";
            const string BanPlayer = "3";
            const string UnBanPlayer = "4";
            const string ShowInfoPlayer = "5";
            const string Exit = "6";

            DataBase database = new DataBase();

            bool isWorking = true;
            Console.WriteLine($"Добавить игрока - {AddPlayer},\nудалить игрока - {RemovePlayer},\nзаблокировать игрока - {BanPlayer},\nразблокировать игрока - {UnBanPlayer}\n" +
                $"показать инфо об игроке - {ShowInfoPlayer},\nвыйти из программы - {Exit}.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        database.AddPlayer();
                        break;
                    case "2":
                        database.DeletePlayer();
                        break;
                    case "3":
                        database.BanPlayer();
                        break;
                    case "4":
                        database.UnbanPlayer();
                        break;
                    case "5":
                        database.ShowPlayers();
                        break;
                    case "6":
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

    class DataBase
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            bool isBanned = false;
            Console.WriteLine("Введите никнейм игрока:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите айди игрока начиная с единицы:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int id);

            Random random = new Random();
            int minLvl = 0;
            int maxLvl = 100;
            int lvl = random.Next(minLvl, maxLvl);

            if (isCorrect == true)
            {
                _players.Add(new Player(name, id, lvl, isBanned));
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
            bool correctInput = int.TryParse(Console.ReadLine(), out int lvl);

            if (correctInput)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players.RemoveAt(lvl - 1);
                    Console.WriteLine("Пользователь удален.");
                }
            }
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите id игрока для блокировки:");
            bool correctInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (correctInput)
            {
                foreach (var player in _players)
                {
                    if (player.Id == userInput && player.IsBanned == false)
                    {
                        player.Ban();
                        Console.WriteLine("Игрок забанен.");
                    }
                    else if (player.Id != userInput)
                    {
                        Console.WriteLine("Такого айди нет.");
                    }
                    else
                    {
                        Console.WriteLine("Игрок уже в бане.");
                    }
                }
            }
        }

        public void UnbanPlayer()
        {
            Console.WriteLine("Введите id для разблокировки:");
            bool correctInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (correctInput)
            {
                foreach (var player in _players)
                {
                    if (player.Id == userInput && player.IsBanned == true)
                    {
                        player.Unban();
                        Console.WriteLine("Игрок разбанен.");
                    }
                    else if (player.Id != userInput)
                    {
                        Console.WriteLine("Такого айди нет.");
                    }
                    else
                    {
                        Console.WriteLine("Игрок не находится в бане.");
                    }
                }
            }
        }

        public void ShowPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowInfo();
            }
        }
    }
}
