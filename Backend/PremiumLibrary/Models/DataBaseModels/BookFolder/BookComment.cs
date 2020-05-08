using System;
using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookComment
    {
        public string Id { get; set; }

        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public List<BookCommentLike> BookCommentLikes { get; set; }
    }
}
