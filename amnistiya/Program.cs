using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace amnistiya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.StartWork();
        }
    }

    class DataBase
    {
        private List<Criminal> _criminals;

        public DataBase()
        {
            Create();
        }

        public void StartWork()
        {
            const string CommandStartWork = "1";
            const string CommandStopWork = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Введите номер операции: {CommandStartWork} - начать амнистию, {CommandStopWork} - выход из программы.");

                switch (Console.ReadLine())
                {
                    case CommandStartWork:
                        ShowInfo();
                        Console.ReadKey();
                        StartAmnesty();
                        break;

                    case CommandStopWork:
                        isWorking = false;
                        break;
                }
            }
        }

        private void StartAmnesty()
        {
            string amnestiedCrime = "Антиправительственное";
            var foundCriminal = _criminals.Where(criminal => criminal.Crime != amnestiedCrime);
            Console.WriteLine();

            foreach (var criminal in foundCriminal)
            {
                criminal.ShowInfo();
            }
        }

        private void ShowInfo()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        private List<Criminal> Create()
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Зубенко Михаил Петрович", "еврей"),
                new Criminal("Чарльз Мэнсон", "убийство"),
                new Criminal("Пабло Эскобак", "кража"),
                new Criminal("Джек-потрошитель", "Антиправительственное"),
                new Criminal("Дик Турпин", "грабеж"),
                new Criminal("Чарльз Бронсон", "Антиправительственное"),
            };

            return _criminals;
        }
    }

    class Criminal
    {
        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }

        public string Name { get; private set; }
        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name}, преступление: {Crime}");
        }
    }
}
