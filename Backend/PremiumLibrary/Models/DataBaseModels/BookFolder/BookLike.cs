namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookLike
    {
        public string Id { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
