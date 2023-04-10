using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace biblioteka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowBooks = "3";
            const string CommandShowBooksFilter = "4";
            const string CommandExit = "5";

            bool isWorking = true;

            Library library = new Library();

            Console.WriteLine($"Введите номер операции:\n{CommandAddBook} - добавить книгу,\n{CommandRemoveBook} - удалить книгу,\n{CommandShowBooks} - показать все книги,\n{CommandShowBooksFilter} - показать книги по фильтру" +
                $"\n{CommandExit} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        library.AddBook();
                        break;

                    case CommandRemoveBook:
                        library.RemoveBook();
                        break;

                    case CommandShowBooks:
                        library.ShowBooks();
                        break;

                    case CommandShowBooksFilter:
                        library.ShowBooksFilter();
                        break;

                    case CommandExit:
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

            if (isCorrect == true && bookNumber < _books.Count && bookNumber > 0)
            {
                for (int i = _books.Count - 1; i >= 0; i--)
                {
                    if (_books[i].Number == bookNumber)
                    {
                        _books.Remove(_books[i]);
                        Console.WriteLine("Книга удалена.");
                    }
                }
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
            const string CommandBookName = "1";
            const string CommandAuthorName = "2";
            const string CommandYearReleaseName = "3";
            const string CommandNumber = "4";

            Console.WriteLine($"Выберите номер операции:\n{CommandBookName} - поиск по названию,\n{CommandAuthorName} - поиск по автору," +
                $"\n{CommandYearReleaseName} - поиск по году выпуска,\n{CommandNumber} - поиск по индексу.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandBookName:
                    ShowByTitle();
                    break;

                case CommandAuthorName:
                    ShowByAuthor();
                    break;

                case CommandYearReleaseName:
                    ShowInfoBook();
                    break;

                case CommandNumber:
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
            List<Book> books = new List<Book>();

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
            List<Book> books = new List<Book>();

            Console.WriteLine("Введите год выпуска:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int year);

            if (isCorrect)
            {
                for (int i = 0; i < _books.Count; i++)
                {

                    if (_books[i].YearRelease == year)
                    {
                        books.Add(_books[i]);
                        _books[i].ShowInfo();
                    }
                }

                if (books.Count == 0)
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
        }

        private void ShowNumberBook()
        {
            List<Book> books = new List<Book>();

            Console.WriteLine("Введите номер книги:");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int number);

            if (isCorrect == true)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Number == number)
                    {
                        books.Add(_books[i]);
                        _books[i].ShowInfo();
                    }
                }

                if (books.Count == 0)
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз.");
            }
        }

        private void Metod()
        {

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