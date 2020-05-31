using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class Author
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ImageUrl { get; set; }

        public virtual List<AuthorLike> AuthorLikes { get; set; }
        public virtual List<AuthorComment> AuthorComments { get; set; }
        public virtual List<AuthorBook> AuthorBooks { get; set; }
    }
}
