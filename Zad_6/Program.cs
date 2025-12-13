using System;
using BookRepository;
class Program
{
    static void Main(string[] args)
    {
        BookRepository.BookRepository repo = new BookRepository.BookRepository();

        // Add a new book
        var newBook = new Book(1, "1984", "George Orwell");
        repo.AddBook(newBook);
        Console.WriteLine("Added book: 1984 by George Orwell");

        // Load and display all books
        var books = repo.LoadBooks();
        Console.WriteLine("Current books in repository:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
        }

        // Update the book
        var updatedBook = new Book(1, "Nineteen Eighty-Four", "George Orwell");
        repo.UpdateBook(updatedBook);
        Console.WriteLine("Updated book ID 1 to Nineteen Eighty-Four");

        // Delete the book
        repo.DeleteBook(1);
        Console.WriteLine("Deleted book with ID 1");
    }
}