using System.Collections.Generic;

namespace PremiumLibrary.Models.ViewModels.Author
{
    public class AuthorCreateModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ImageUrl { get; set; }
        public List<string> BooksId { get; set; }
    }
}