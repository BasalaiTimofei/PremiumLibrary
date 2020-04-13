using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumLibrary.Models.DataBaseModels.Book;

namespace PremiumLibrary.Models.ViewModels.Book
{
    public class BookCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
        public int Year { get; set; }

        public List<string> Genres { get; set; }
        public List<string> Authors { get; set; }
    }
}
