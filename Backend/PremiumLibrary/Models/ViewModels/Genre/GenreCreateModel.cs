using System.Collections.Generic;

namespace PremiumLibrary.Models.ViewModels.Genre
{
    public class GenreCreateModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Books { get; set; }
    }
}