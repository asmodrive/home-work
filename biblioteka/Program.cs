using System;
using System.Collections.Generic;

namespace biblioteka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddBook = "1";
            const string RemoveBook = "2";
            const string ShowBooks = "3";
            const string ShowBooksFilter = "4";
            const string Exit = "5";

            bool isWorking = true;

            Library library = new Library();

            Console.WriteLine($"Введите номер операции:\n{AddBook} - добавить книгу,\n{RemoveBook} - удалить книгу,\n{ShowBooks} - показать все книги,\n{ShowBooksFilter} - показать книги по фильтру" +
                $"\n{Exit} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBook:
                        library.AddBook();
                        break;

                    case RemoveBook:
                        library.RemoveBook();
                        break;

                    case ShowBooks:
                        library.ShowBooks();
                        break;

                    case ShowBooksFilter:
                        library.ShowBooksFilter();
                        break;

                    case Exit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>()
        {
             new Book("ДА", "debil", 2012, 1),
            new Book("ty", "net", 1865, 2),
            new Book("tt", "kakbida", 2054, 3),
            new Book("net", "pizdec", 1985, 4),
        };

        public void AddBook()
        {
            Console.WriteLine("Введите название книги:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите автора:");
            string author = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int yearRelease);
            Console.WriteLine("Введите номер книги:");
            isCorrect = int.TryParse(Console.ReadLine(), out int number);

            if (isCorrect == true)
            {
                _books.Add(new Book(name, author, yearRelease, number));
                Console.WriteLine("Книга добавлена.");
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
        }

        public void RemoveBook()
        {
            Console.WriteLine("Введите номер книги для удаления:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int bookNumber);

            if (isCorrect == true && bookNumber < _books.Count)
            {
                _books.RemoveAt(bookNumber);
                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Такой книги нет.");
            }
        }

        public void ShowBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                _books[i].ShowInfo();
            }
        }

        public void ShowBooksFilter()
        {
            const string bookName = "1";
            const string authorName = "2";
            const string yearReleaseName = "3";
            const string number = "4";

            Console.WriteLine($"Выберите номер операции:\n{bookName} - поиск по названию,\n{authorName} - поиск по автору,\n{yearReleaseName} - поиск по году выпуска,\n{number} - поиск по индексу.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case bookName:
                    ShowByTitle();
                    break;

                case authorName:
                    ShowByAuthor();
                    break;

                case yearReleaseName:
                    ShowInfoBook();
                    break;

                case number:
                    ShowNumberBook();
                    break;
            }
        }

        private void ShowByTitle()
        {
            Console.WriteLine("Введите название книги:");
            string userInput = Console.ReadLine().ToLower();

            for (int i = 0; i < _books.Count; i++)
            {

                if (_books[i].Name.ToLower().Contains(userInput))
                {
                    _books[i].ShowInfo();
                     break;
                }
                else
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }

        }

        private void ShowByAuthor()
        {
            Console.WriteLine("Введите автора:");
            string userInput = Console.ReadLine().ToLower();

            for (int i = 0; i < _books.Count; i++)
            {

                if (_books[i].Author.ToLower().Contains(userInput))
                {
                    _books[i].ShowInfo();
                    break;
                }
                else
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }
        }

        private void ShowInfoBook()
        {
            Console.WriteLine("Введите год выпуска:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int year);

            for (int i = 0; i < _books.Count; i++)
            {

                if (_books[i].YearRelease == year)
                {
                    _books[i].ShowInfo();
                    break;
                }
                else
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }
        }

        private void ShowNumberBook()
        {
            Console.WriteLine("Введите номер книги:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int number);

            for (int i = 0; i < _books.Count; i++)
            {

                if (_books[i].Number == number)
                {
                    _books[i].ShowInfo();
                    break;
                }
                else
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }
        }
    } 

    class Book
    {
        public Book(string name, string author, int yearRelease, int number)
        {
            Name = name;
            Author = author;
            YearRelease = yearRelease;
            Number = number;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearRelease { get; private set; }
        public int Number { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Name}, автор: {Author}, год выпуска: {YearRelease}, номер книги: {Number}.");
        }
    }
}


