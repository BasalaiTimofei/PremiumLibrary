using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels.GenreFolder
{
    public class Genre
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual List<GenreLike> Likes { get; set; }
        public virtual List<GenreBook> Books { get; set; }
    }
}