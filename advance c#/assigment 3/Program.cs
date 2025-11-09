using System;
using System.Collections.Generic;

namespace assigment_3
{
    public delegate string BookDelegate(Book book);

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string ISBN, string Title, string[] Authors, DateTime PublicationDate, decimal Price)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Authors = Authors;
            this.PublicationDate = PublicationDate;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Price: ${Price}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return $"Title: {B.Title}";
        }

        public static string GetAuthors(Book B)
        {
            return $"Authors: {string.Join(", ", B.Authors)}";
        }

        public static string GetPrice(Book B)
        {
            return $"Price: ${B.Price}";
        }
    }

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Book> books = new List<Book>
            {
                new Book("978-0-7432-7356-5", "The C# Player's Guide", new[] { "RB Whitaker" }, new DateTime(2022, 1, 15), 49.99m),
                new Book("978-0-13-468599-1", "C# Programming", new[] { "Andrew Troelsen", "Phil Japikse" }, new DateTime(2021, 6, 10), 59.99m),
                new Book("978-1-4919-2993-8", "Effective C#", new[] { "Bill Wagner" }, new DateTime(2020, 3, 22), 45.99m)
            };

            BookDelegate userDelegateTitle = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, userDelegateTitle);

            Console.WriteLine("/nCase B: BCL Delegates (Func<>) ");
            Func<Book, string> bclDelegateAuthors = BookFunctions.GetAuthors;
            foreach (Book B in books)
            {
                Console.WriteLine(bclDelegateAuthors(B));
            }

            Console.WriteLine("\nCase C: Anonymous Method (GetISBN) ");
            BookDelegate anonDelegate = delegate(Book B)
            {
                return $"ISBN: {B.ISBN}";
            };
            LibraryEngine.ProcessBooks(books, anonDelegate);

            Console.WriteLine("\n Case D: Lambda Expression (GetPublicationDate) ");
            BookDelegate lambdaDelegate = (Book B) => $"Publication Date: {B.PublicationDate:yyyy-MM-dd}";
            LibraryEngine.ProcessBooks(books, lambdaDelegate);

            Console.WriteLine("\n Case E: Lambda with GetPrice ");
            BookDelegate lambdaPrice = B => $"Price: ${B.Price}";
            LibraryEngine.ProcessBooks(books, lambdaPrice);

        }
    }
}
