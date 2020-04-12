namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class GenreBook
    {
        public string Id { get; set; }

        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}