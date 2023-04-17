using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();
            terminal.Work();
        }
    }

    class Terminal
    {
        private const ConsoleKey CommandEnter = ConsoleKey.Enter;
        private List<Train> _trains = new List<Train>();

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Для создания маршрута нажмите {CommandEnter}");
                EnterToContinue();
                Console.WriteLine($"Для продажи билетов нажмите {CommandEnter}");
                EnterToContinue();
                Directon directon = new Directon();
                SendTrain(directon.StartingPoint, directon.Destination);
                Console.WriteLine($"Для отравки поезда нажмите {CommandEnter}");
                EnterToContinue();
                ShowSendsTrains();
            }
        }

        public void ShowInfo(Train train)
        {
            Console.WriteLine($"Поезд {train.StartingPoint} - {train.Destination} с {train.SeatsQuantity} вагонами");
        }

        private void EnterToContinue()
        {
            bool isWorking = true;

            while (isWorking)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == CommandEnter)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"Такой команды нет");
                }
            }
        }

        private int SellTickets(int passengers)
        {
            int minPassengers = 20;
            int maxPassengers = 760;
            Random random = new Random();
            passengers = random.Next(minPassengers, maxPassengers);
            return passengers;
        }

        private void ShowPassengersInfo(Train train)
        {
            Console.WriteLine($"Билеты приобрели: {train.Passengers}, нажмите {ConsoleKey.Enter} для отправки.");
        }

        private void SendTrain(string startingPoint, string destination)
        {
            int passengers = 0;
            passengers = SellTickets(passengers);
            Train train = new Train(passengers, startingPoint, destination);
            _trains.Add(train);
            ShowPassengersInfo(train);
        }

        private void ShowSendsTrains()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Отправленные поезда:\n");

            for (int i = 0; i < _trains.Count; i++)
            {
                ShowInfo(_trains[i]);
            }

            Console.WriteLine();
        }
    }

    class Train
    {
        public Train(int passengers, string startingPoint, string destination)
        {
            Passengers = passengers;
            StartingPoint = startingPoint;
            Destination = destination;
            SeatsQuantity = CreateTrain(Passengers);
        }

        public int Passengers { get; private set; }
        public int SeatsQuantity { get; private set; }
        public string StartingPoint { get; private set; }
        public string Destination { get; private set; }
        public int SeatsMax { get; private set; } = 20;

        private int CreateTrain(int passengers)
        {
            int needCountSeats = passengers / SeatsMax;

            if (passengers % SeatsMax != 0)
            {
                needCountSeats++;
            }

            return needCountSeats;
        }
    }

    class Directon
    {
        public string StartingPoint { get; private set; }
        public string Destination { get; private set; }

        public Directon()
        {
            SetDirection();
        }

        private void SetDirection()
        {
            List<string> cities = new List<string>{ "Москва", "Стамбул", "Харьков", "Дрезден", "Париж", "Мадрид" };
            Random random = new Random();

            while (Destination == StartingPoint)
            {
                int cityIndex = random.Next(cities.Count);
                int cityIndex2 = random.Next(cities.Count);
                Destination = cities[cityIndex];
                StartingPoint = cities[cityIndex2];
            }

            Console.WriteLine($"Направление поезда {Destination} - {StartingPoint}");
        }
    }
}