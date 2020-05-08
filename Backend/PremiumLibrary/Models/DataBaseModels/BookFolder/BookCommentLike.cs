namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookCommentLike
    {
        public string Id { get; set; }

        public string BookCommentId { get; set; }
        public BookComment BookComment { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
