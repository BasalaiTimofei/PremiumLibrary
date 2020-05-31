namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookAssessment
    {
        public string Id { get; set; }

        //TODO от 1 до 10 
        public int Count { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
