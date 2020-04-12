namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class BookLike
    {
        public string Id { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
