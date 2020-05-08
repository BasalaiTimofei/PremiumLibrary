namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class AuthorCommentLike
    {
        public string Id { get; set; }

        public string AuthorCommentId { get; set; }
        public AuthorComment AuthorComment { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
