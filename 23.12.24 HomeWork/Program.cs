using System;
using System.Collections.Generic;
using System.Text;

namespace _23._12._24_HomeWork
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Назва книги: {Title}, Автор книги: {Author}, Рік випуску: {Year}");
        }
    }

    public class Ebook : Book
    {
        public double FileSize { get; set; } // Розмір файлу МБ

        public Ebook(string title, string author, int year, double fileSize)
            : base(title, author, year)
        {
            FileSize = fileSize;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Розмір файлу: {FileSize} МБ");
            Console.WriteLine();
        }
    }

    public class PrintedBook : Book
    {
        public double Weight { get; set; } // Вага книги 

        public PrintedBook(string title, string author, int year, double weight)
            : base(title, author, year)
        {
            Weight = weight;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Вага книги: {Weight} кг");
            Console.WriteLine();
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();
        public event Action<string> BookAdded;

        public void AddBook(Book book)
        {
            books.Add(book);
            BookAdded?.Invoke($"Книга '{book.Title}' додана до бібліотеки.");
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("Список всіх книг в бібліотеці:");
            Console.WriteLine();
            foreach (var book in books)
            {
                book.ShowInfo();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Library library = new Library();

            library.BookAdded += (message) => Console.WriteLine(message);

            Book book1 = new PrintedBook("Велика подорож", "Іван Франко", 1900, 0.8);
            Book book2 = new Ebook("Магія програмування", "Роберт Мартін", 2015, 5.2);
            Book book3 = new PrintedBook("Історія України", "Михайло Грушевський", 2000, 1.2);
            Book book4 = new Ebook("Математика для початківців", "Алгоритм Чей", 2010, 3.8);

            library.AddBook(book1);
            Console.WriteLine();
            library.AddBook(book2);
            Console.WriteLine();
            library.AddBook(book3);
            Console.WriteLine();
            library.AddBook(book4);
            Console.WriteLine();

            library.ShowAllBooks();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
