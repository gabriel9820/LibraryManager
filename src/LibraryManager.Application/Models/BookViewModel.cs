using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class BookViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    public bool IsAvailable { get; private set; }

    public BookViewModel(int id, string title, string author, string isbn, int publicationYear, bool isAvailable)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
        IsAvailable = isAvailable;
    }
}

public static class BookViewModelExtensions
{
    public static BookViewModel ToViewModel(this Book book)
    {
        return new BookViewModel(
            book.Id,
            book.Title,
            book.Author,
            book.ISBN,
            book.PublicationYear,
            book.IsAvailable);
    }
}