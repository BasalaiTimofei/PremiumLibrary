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
        public virtual User User { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public virtual List<BookCommentLike> BookCommentLikes { get; set; }
    }
}
