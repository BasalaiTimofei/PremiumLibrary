namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class AuthorLike
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
