using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine($"Введите номер операции:\n{AddBook} - добавить книгу,\n{RemoveBook} - удалить книгу,\n{ShowBooks} - показать все книги,\n{ShowBooksFilter} - показать книги по фильтру" +
                $"\n{Exit} - выйти из программы.");

            while (isWorking)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBook:

                        break;

                    case RemoveBook:

                        break;

                    case ShowBooks:

                        break;

                    case ShowBooksFilter:

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
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {
            Console.WriteLine("Введите название книги:");
            Console.WriteLine("Введите автора:");
            Console.WriteLine("Введите год выпуска:");
            _books.Add(new Book());
        }
    }

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearRelease { get; private set; }
    }

}
