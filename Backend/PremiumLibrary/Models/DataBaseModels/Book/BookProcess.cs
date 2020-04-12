namespace PremiumLibrary.Models.DataBaseModels.Book
{
    public class BookProcess
    {
        public string Id { get; set; }

        //TODO 0-буду, 1-читаю, 2-прочитал, 3-бросил
        public int Process { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
