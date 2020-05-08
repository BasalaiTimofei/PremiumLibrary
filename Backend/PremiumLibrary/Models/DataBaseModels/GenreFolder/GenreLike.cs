namespace PremiumLibrary.Models.DataBaseModels.GenreFolder
{
    public class GenreLike
    {
        public string Id { get; set; }

        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
