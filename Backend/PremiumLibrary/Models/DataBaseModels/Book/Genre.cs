using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class Genre
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<GenreLike> Likes { get; set; }
        public List<GenreBook> Books { get; set; }
    }
}
