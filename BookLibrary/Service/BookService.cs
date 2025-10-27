using BookLibrary.Domain;

namespace BookLibrary.Service;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();
    public void Add(Book book)
    {
        _books.Add(book);
    }

    public Book? FindByName(string author)
    {
        return _books.FirstOrDefault(x =>
            string.Equals(x.Author, author, StringComparison.OrdinalIgnoreCase));
    }


    public List<Book> GetAll()
    {
        return _books.ToList();
    }

    public List<Book> GetAvailableBooks()
    {
        return _books.Where(x => x.InStock).ToList();
    }

    

    public bool RemoveByTitle(string title)
    {
        var found = _books.FirstOrDefault(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (found != null)
        {
            _books.Remove(found);
            return true;
        }
        return false;
    }
}
