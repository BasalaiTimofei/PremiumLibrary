using System.Collections.Generic;
using PremiumLibrary.Models.DataBaseModels.Book;

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
        public List<AuthorLike> AuthorLikes { get; set; }
        public List<AuthorComment> AuthorComments { get; set; }
        public List<AuthorCommentLike> AuthorCommentLikes { get; set; }
        public List<BookAssessment> BookAssessments { get; set; }
        public List<BookComment> BookComments { get; set; }
        public List<BookCommentLike> BookCommentLikes { get; set; }
        public List<BookLike> BookLikes { get; set; }
        public List<BookProcess> BookProcesses { get; set; }
        public List<GenreLike> GenreLikes { get; set; }
    }
}