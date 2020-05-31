using System.Collections.Generic;
using PremiumLibrary.Models.DataBaseModels.AuthorFolder;
using PremiumLibrary.Models.DataBaseModels.GenreFolder;

namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class Book
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageIrl { get; set; }
        public string BookUrl { get; set; }
        public int Year { get; set; }

        public virtual List<BookAssessment> Assessments { get; set; }
        public virtual List<GenreBook> Genres { get; set; }
        public virtual List<AuthorBook> Authors { get; set; }
        public virtual List<BookComment> Comments { get; set; }
        public virtual List<BookLike> Likes { get; set; }
        public virtual List<BookProcess> Processes { get; set; }
    }
}