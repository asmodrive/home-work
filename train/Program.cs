using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCreateDirection = "1";
            const string CommandSellTickets = "2";
            const string CommandCreateTrain = "3";
            const string CommandSendTrain = "4";
            const string CommandExit = "5";

            int passengers = 0;
            string startingPoint = string.Empty;
            string endPoint = string.Empty;

            Terminal terminal = new Terminal();

            bool isWorking = true;

            while (isWorking)
            {
                terminal.ShowSendsTrains();

                Console.WriteLine($"Введите название операции:\n{CommandCreateDirection} - создать направление,\n{CommandSellTickets} - продать билеты,\n{CommandCreateTrain} - создать поезд," +
                    $"\n{CommandSendTrain} - отправить поезд,\n{CommandExit} - выйти из программы.");

                switch (Console.ReadLine())
                {
                    case CommandCreateDirection:
                        terminal.CreateDirection();
                        break;

                    case CommandSellTickets:
                        
                        terminal.SellTickets(passengers);
                        break;

                    case CommandCreateTrain:

                        break;

                    case CommandSendTrain:
                        terminal.SendTrain(startingPoint, endPoint);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Train
    {
        public Train (string startingPoint, string destination, int seatsQuantity, int passengers)
        {
            StartingPoint = startingPoint;
            Destination = destination;
            SeatsQuantity = seatsQuantity;
            Passengers = passengers;
            CountWagon = CreateTrain(Passengers);
        }

        private List<Train> _trains = new List<Train>();
        public string StartingPoint { get; private set; }
        public string Destination { get; private set; }
        public int CountWagon { get; private set; }
        public int Passengers { get; private set; }
        public int SeatsQuantity { get; private set; } = 20;

        public int CreateTrain(int passengers)
        {
            int seatsCout = passengers / SeatsQuantity;

            if (passengers % SeatsQuantity != 0)
            {
                seatsCout++;
            }

            return seatsCout;
        }
    }

    class Terminal
    {
        public Terminal ()
        {
            _trains = new List<Train> ();
        }

        private List<Train> _trains;

        public void CreateDirection()
        {
            ShowInfoCities();
            Console.WriteLine("Введите город отправления:");
            string startingPoint = Console.ReadLine();
            Console.WriteLine("Введите город прибытия:");
            string destination = Console.ReadLine();
            Console.WriteLine($"Поезд выезжает из города: {startingPoint}, в город: {destination}.");
        }

        public int SellTickets(int passengers)
        {
            int minValue = 25;
            int maxValue = 100;
            Random random = new Random();
            passengers = random.Next(minValue, maxValue);
            Console.WriteLine($"Билеты купили {passengers} пассажиров.");

            return passengers;
        }

        public void SendTrain(string startingPoint, string destination)
        {
            int passengers = 0;
            passengers = SellTickets(passengers);
            //Train train = new Train(startingPoint, destination, passengers);
           // _trains.Add(train);
        }

        public void ShowInfoCities()
        {
            List<string> cities = new List<string> { "Москва", "Стамбул", "Харьков", "Дрезден", "Париж", "Мадрид" };

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }
        }

        public void ShowInfo(Train train)
        {
            Console.WriteLine($"Поезд {train.StartingPoint} - {train.Destination} с {train.CountWagon} вагонами");
        }

        public void ShowSendsTrains()
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

}
