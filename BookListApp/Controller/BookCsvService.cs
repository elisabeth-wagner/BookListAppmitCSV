using BookListApp.Models;

namespace BookListApp.Controller
{
    public class BookCsvService
    {
        private readonly IWebHostEnvironment _env;

        public BookCsvService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<List<Book>> LoadBooksAsync()
        {
            var books = new List<Book>();

            string filePath = Path.Combine(_env.WebRootPath, "books.csv");

            if (!File.Exists(filePath))
                return books;

            var lines = await File.ReadAllLinesAsync(filePath);

            foreach (var line in lines.Skip(1)) // пропускаем заголовок
            {
                var parts = line.Split(',');

                if (parts.Length == 3)
                {
                    books.Add(new Book
                    {
                        Title = parts[0],
                        Author = parts[1],
                        Year = int.Parse(parts[2])
                    });
                }
            }

            return books;
        }
    }
}
