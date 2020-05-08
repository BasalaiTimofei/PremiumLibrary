using System;

namespace PremiumLibrary.Models.ViewModels.Comment
{
    public class BookCommentListingModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Likes { get; set; }
        public bool Like { get; set; }
        public DateTime DateTime { get; set; }
    }
}
