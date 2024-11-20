using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    // Define the Book class
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(int bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }

    // Define the Library class
    public class Library
    {
        private List<Book> Books;

        public Library()
        {
            Books = new List<Book>();
        }

     
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Added: {book.Title} by {book.Author}");
        }

   
        public void BorrowBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine($"Borrowed: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book not available for borrowing.");
            }
        }

        
        public void ReturnBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null && !book.IsAvailable)
            {
                book.IsAvailable = true;
                Console.WriteLine($"Returned: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book is not borrowed or does not exist.");
            }
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Books in Library:");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Available: {book.IsAvailable}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book(1, "The Great Gatsby", "F. Scott Fitzgerald"));
            library.AddBook(new Book(2, "To Kill a Mockingbird", "Harper Lee"));
            library.AddBook(new Book(3, "1984", "George Orwell"));

            library.DisplayBooks();
            Console.WriteLine();

            library.BorrowBook(2);
            Console.WriteLine();

            library.BorrowBook(2);
            Console.WriteLine();

            library.DisplayBooks();
            Console.WriteLine();

            library.ReturnBook(2);
            Console.WriteLine();

            library.DisplayBooks();
        }
    }
}
