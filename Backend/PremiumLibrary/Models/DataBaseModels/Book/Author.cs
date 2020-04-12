using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class Author
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ImageUrl { get; set; }

        public List<AuthorLike> AuthorLikes { get; set; }
        public List<AuthorComment> AuthorComments { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
