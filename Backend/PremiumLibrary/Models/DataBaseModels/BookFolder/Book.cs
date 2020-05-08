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

        public List<BookAssessment> Assessments { get; set; }
        public List<GenreBook> Genres { get; set; }
        public List<AuthorBook> Authors { get; set; }
        public List<BookComment> Comments { get; set; }
        public List<BookLike> Likes { get; set; }
        public List<BookProcess> Processes { get; set; }
    }
}