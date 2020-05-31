using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Models.DataBaseModels.GenreFolder
{
    public class GenreBook
    {
        public string Id { get; set; }

        public string GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}