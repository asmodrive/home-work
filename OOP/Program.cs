using System;
using System.Collections.Generic;

namespace Program.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int AddPlayer = 1;
            const int DeletePlayer = 2;
            const int BanPlayer = 3;
            const int UnBanPlayer = 4;
            const int ShowDataBase = 5;

            bool isWorking = true;
            DataBase dataProcessing = new DataBase();

            while (isWorking)
            {
                Console.WriteLine($"Добро пожаловать в базу данных игроков.\nВам доступны слудующие функции работы с базой:\n{AddPlayer}- Добавить игрока\n{DeletePlayer}- Удалить игрока\n" +
                              $"{BanPlayer}- Забанить игрока\n{UnBanPlayer}- Разбанить игрока\n{ShowDataBase}- Показать базу данных\nВыберите необходимый вариант:\n");

                bool isCorrect = int.TryParse(Console.ReadLine(), out int userInput);

                if (isCorrect && userInput < 6)
                {
                    switch (userInput)
                    {
                        case AddPlayer:
                            dataProcessing.CreatePlayer();
                            break;

                        case DeletePlayer:
                            dataProcessing.DeletePlayer();
                            break;

                        case BanPlayer:
                            dataProcessing.BanPlayer();
                            break;

                        case UnBanPlayer:
                            dataProcessing.UnBanPlayer();
                            break;

                        case ShowDataBase:
                            dataProcessing.ShowDataBase();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверно введена команда! Повторите запрос!");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        public Player(int playerId, string playerNickname, int playerLeavel, bool playerFlag)
        {
            PlayerId = playerId;
            PlayerIsBanned = playerFlag;
            _playerNickname = playerNickname;
            _playerLeavel = playerLeavel;
        }

        public int PlayerId { get; private set; }
        public bool PlayerIsBanned { get; private set; }
        private int _playerLeavel;
        private string _playerNickname;

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер: {PlayerId}\nИмя: {_playerNickname}\nУровень персонажа: {_playerLeavel}\nЗабанен: {PlayerIsBanned}\n");
        }

        public void Ban()
        {
            PlayerIsBanned = true;
        }

        public void UnBan()
        {
            PlayerIsBanned = false;
        }
    }

    class DataBase
    {
        private List<Player> _players = new List<Player>();

        public void CreatePlayer()
        {
            Console.WriteLine("Введите ник игрока:");
            string nickName = Console.ReadLine();
            bool playerFlag = false;

            Console.WriteLine("Введите уровень игрока:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int playerLeavel);

            if (isCorrect == false)
            {
                Console.WriteLine("Ошибка! Некорректный уровень игрока!");
            }

            Random random = new Random();
            int minId = 1;
            int maxId = 100;
            int newId = random.Next(minId, maxId);

            if (playerLeavel > 0)
            {
                _players.Add(new Player(newId, nickName, playerLeavel, playerFlag));
                Console.WriteLine("Игрок добавлен.");
            }
            else
            {
                Console.WriteLine("Введены некоректные данные, игрок не добавлен! Повторите ввод данных!");
            }
        }

        public void ShowDataBase()
        {
            if (_players.Count > 0)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В базе данных отсутствуют игроки.");
            }
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите номер игрока желаемого забанить:\n");
            bool isCorrectUserInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (isCorrectUserInput)
            {
                foreach (var player in _players)
                {
                    if (player.PlayerId == userInput && player.PlayerIsBanned == false)
                    {
                        player.Ban();
                        Console.WriteLine("Игрок забанен.\n");
                    }
                    else if (player.PlayerId != userInput)
                    {
                        Console.WriteLine("Некорректный номер игрока!\n");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Игрок уже забанен!\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный номер игрока!\n");
            }
        }

        public void UnBanPlayer()
        {
            Console.WriteLine("Введите номер игрока желаемого разбанить:\n");
            bool isCorrectUserInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (isCorrectUserInput)
            {
                foreach (var player in _players)
                {
                    if (player.PlayerId == userInput && player.PlayerIsBanned == true)
                    {
                        player.UnBan();
                        Console.WriteLine("Игрок разбанен.\n");
                    }
                    else if (player.PlayerId != userInput)
                    {
                        Console.WriteLine("Некорректный номер игрока!\n");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Игрок уже разбанен!\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный номер игрока!\n");
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите номер игрока для его удаления:\n");
            bool isCorrectUserImput = int.TryParse(Console.ReadLine(), out int userImput);

            if (isCorrectUserImput && userImput > 0)
            {
                Player playerToRemove = _players.Find(p => p.PlayerId == userImput);

                if (playerToRemove != null)
                {
                    _players.Remove(playerToRemove);
                    Console.WriteLine("Игрок удален.\n");
                }
                else
                {
                    Console.WriteLine("Некорректный номер игрока!\n");
                }
            }
        }
    }
}