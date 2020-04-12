using System;
using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class AuthorComment
    {
        public string Id { get; set; }

        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public string AuthorId { get; set; }
        public Author Author { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<AuthorCommentLike> AuthorCommentLikes { get; set; }
    }
}
