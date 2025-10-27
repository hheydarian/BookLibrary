using BookLibrary.Domain;

namespace BookLibrary.Service;

public interface IBookService
{
    void Add(Book book);
    bool RemoveByTitle(string title);
    Book? FindByName(string author);
    List<Book> GetAll();
    List<Book> GetAvailableBooks();


}
