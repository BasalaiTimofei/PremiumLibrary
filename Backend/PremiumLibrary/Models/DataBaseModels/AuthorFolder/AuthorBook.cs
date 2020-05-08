using PremiumLibrary.Models.DataBaseModels.BookFolder;

namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class AuthorBook
    {
        public string Id { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public string AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
