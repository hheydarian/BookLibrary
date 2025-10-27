
using BookLibrary.Domain;
using BookLibrary.Service;

class Program
{
    static void Main()
    {
        IBookService bookService = new BookService();

        while (true)
        {
            Console.WriteLine("=== Book Library ===");
            Console.WriteLine("1) Add Book");
            Console.WriteLine("2) List All");
            Console.WriteLine("3) List Available");
            Console.WriteLine("4) Find by Author");
            Console.WriteLine("5) Remove by Title");
            Console.WriteLine("0) Exit");

            string chise = Console.ReadLine() ?? "";
            switch (chise)
            {
                case "1":
                    Console.WriteLine("Enter Title:");
                    string title = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter Author:");
                    string author = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter Price:");
                    int price = int.Parse(Console.ReadLine() ?? "0");
                    bookService.Add(new Book(title, author, price));
                    Console.WriteLine("Added book successfuly!");
                    break;
                case "2":
                    foreach (var b in bookService.GetAll())
                    {
                        b.PrintInfo();
                    }
                    break;
                case "3":
                    foreach (var b in bookService.GetAvailableBooks())
                    {
                        b.PrintInfo();
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter Name Author:");
                    var found = bookService.FindByName(Console.ReadLine() ?? "");
                    if (found != null)
                    {
                        found.PrintInfo();
                    }
                    else
                    {
                        Console.WriteLine("Not Found!");
                    }
                    break;

                case "5":
                    Console.WriteLine("Enter Name:");
                    bool removed = bookService.RemoveByTitle(Console.ReadLine() ?? "");
                    Console.WriteLine(removed ? "Removed" : "Not Found!");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("InValid Choise");
                    break;
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

    }
}