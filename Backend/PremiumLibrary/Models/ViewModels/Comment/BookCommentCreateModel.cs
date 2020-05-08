namespace PremiumLibrary.Models.ViewModels.Comment
{
    public class BookCommentCreateModel
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string Comment { get; set; }
    }
}
