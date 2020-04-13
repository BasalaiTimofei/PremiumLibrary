namespace PremiumLibrary.Models.ViewModels.Author
{
    public class AuthorListingModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }

        public bool Like { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Books { get; set; }
    }
}
