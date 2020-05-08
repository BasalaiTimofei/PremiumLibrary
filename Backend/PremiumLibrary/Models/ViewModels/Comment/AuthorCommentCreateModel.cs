namespace PremiumLibrary.Models.ViewModels.Comment
{
    public class AuthorCommentCreateModel
    {
        public string UserId { get; set; }
        public string AuthorId { get; set; }
        public string Comment { get; set; }
    }
}