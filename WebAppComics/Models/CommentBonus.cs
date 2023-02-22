namespace WebAppComics.Models
{
    public class CommentBonus
    {
        public int CommnentId { get; set; }

        public string? CommnentContent { get; set; }

        public DateTime? Date { get; set; }

        public Guid? ChapterId { get; set; }

        public int AccountId { get; set; }

    }
}
