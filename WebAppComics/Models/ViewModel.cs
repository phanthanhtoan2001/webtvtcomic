namespace WebAppComics.Models
{
    public class ViewModel
    {
        public string? ComicName { get; set; }

        public string Describe { get; set; } = null!;

        public string? ComicBanner { get; set; }

        public DateTime? DateSummitted { get; set; }

        public int? Rating { get; set; }
        public string? CategoryName { get; set; }

        public string? Note { get; set; }
    }
}
