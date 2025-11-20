using System.Text.Json.Serialization;

namespace BookListApp.Models
{
    public class Book
    {
        public Guid ID { get; set; }   // Supabase PK (uuid)
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Book other) return false;

            return 
                   ID == other.ID &&
                   Title == other.Title &&
                   Author == other.Author &&
                   Year == other.Year &&
                   Description == other.Description &&
                   Image_Url == other.Image_Url;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Title, Author, Year, Description, Image_Url);
        }
    }
}
