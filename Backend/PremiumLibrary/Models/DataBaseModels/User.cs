using System.Collections.Generic;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.BookFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Models.DataBaseModels
{
    public class User
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<UserRole> Roles { get; set; }
        public virtual List<AuthorLike> AuthorLikes { get; set; }
        public virtual List<AuthorComment> AuthorComments { get; set; }
        public virtual List<AuthorCommentLike> AuthorCommentLikes { get; set; }
        public virtual List<BookAssessment> BookAssessments { get; set; }
        public virtual List<BookComment> BookComments { get; set; }
        public virtual List<BookCommentLike> BookCommentLikes { get; set; }
        public virtual List<BookLike> BookLikes { get; set; }
        public virtual List<BookProcess> BookProcesses { get; set; }
        public virtual List<GenreLike> GenreLikes { get; set; }
    }
}