namespace BookListApp.Models
{
    public class Book
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int Year { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Book other) return false;

            return Title == other.Title &&
                   Author == other.Author &&
                   Year == other.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
    }
}
