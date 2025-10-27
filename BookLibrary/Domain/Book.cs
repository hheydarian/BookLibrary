namespace BookLibrary.Domain;

public class Book
{
    private string _title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value), "Title cannot empty.");
    }
    private string _author
    {
        get => _author;
        set => _author = value ?? throw new ArgumentNullException(nameof(value), "Author cannot empty");
    }
    private int _price
    {
        get => _price;
        set
        {
            if (value < 0 || value > 10000000)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price not support range");
            }
            _price = value;
        }
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }
    public bool InStock => Price > 0;

    public Book(string title, string author, int price)
    {
        Title = title;
        Author = author;
        Price = price;
        
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Price: {Price}, InStock: {InStock} ");
    }
}
