namespace PremiumLibrary.Models.ViewModels.Genre
{
    public class GenreListingModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Likes { get; set; }
        public bool Like { get; set; }
    }
}