namespace PremiumLibrary.Models.DataBaseModels.BookFolder
{
    public class BookProcess
    {
        public string Id { get; set; }

        //TODO 1-буду, 2-читаю, 3-прочитал, 4-бросил
        public int Process { get; set; }

        public string BookId { get; set; }
        public virtual Book Book { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
