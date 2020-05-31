using System;
using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.AuthorFolder
{
    public class AuthorComment
    {
        public string Id { get; set; }

        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public string AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<AuthorCommentLike> AuthorCommentLikes { get; set; }
    }
}
