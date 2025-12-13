using System.Text.Json;
namespace BookRepository
{
public record Book(int Id, string Title, string Author);

public class BookRepository
{
    private readonly string filePath = "books.json";

    public List<Book> LoadBooks()
    {
        if (!File.Exists(filePath))
        {
            return new List<Book>();
        }

        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Book>>(jsonString) ?? new List<Book>();
    }
    public void SaveBooks(List<Book> books)
    {
        string jsonString = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }
    public void AddBook(Book book)
    {
        var books = LoadBooks();
        books.Add(book);
        SaveBooks(books);
    }
    public void UpdateBook(Book updatedBook)
    {
        var books = LoadBooks();
        var index = books.FindIndex(b => b.Id == updatedBook.Id);
        if (index != -1)
        {
            books[index] = updatedBook;
            SaveBooks(books);
        }
    }
    public void DeleteBook(int bookId)
    {
        var books = LoadBooks();
        books.RemoveAll(b => b.Id == bookId);
        SaveBooks(books);
    }
    
}
}