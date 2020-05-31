namespace PremiumLibrary.Models.DataBaseModels.GenreFolder
{
    public class GenreLike
    {
        public string Id { get; set; }

        public string GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
