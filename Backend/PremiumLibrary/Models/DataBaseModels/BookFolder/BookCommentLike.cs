namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookCommentLike
    {
        public string Id { get; set; }

        public string BookCommentId { get; set; }
        public virtual BookComment BookComment { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
