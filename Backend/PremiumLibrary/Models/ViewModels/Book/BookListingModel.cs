using System.Collections.Generic;

namespace PremiumLibrary.Models.ViewModels.Book
{
    public class BookListingModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
        public int Year { get; set; }

        public int Assessment { get; set; }
        public int YourAssessment { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Authors { get; set; }
        public int Comments { get; set; }
        public int Likes { get; set; }
        public bool Like { get; set; }
        public int Process { get; set; }
    }
}
