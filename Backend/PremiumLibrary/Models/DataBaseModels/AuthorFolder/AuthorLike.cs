namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class AuthorLike
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }
        public Author Author { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
