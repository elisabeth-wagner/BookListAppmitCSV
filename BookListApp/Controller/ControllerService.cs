using BookListApp.Models;

public class ControllerService
{
    private readonly List<Book> favorites = new();

    public IReadOnlyList<Book> Favorites => favorites;

    public void ToggleFavorite(Book book)
    {
        if (IsFavorite(book))
            favorites.Remove(book);
        else
            favorites.Add(book);
    }

    public bool IsFavorite(Book book) => favorites.Any(f =>
        f.Title == book.Title &&
        f.Author == book.Author &&
        f.Year == book.Year
    );

    public void Remove(Book book)
    {
        favorites.RemoveAll(f =>
            f.Title == book.Title &&
            f.Author == book.Author &&
            f.Year == book.Year
        );
    }
}
