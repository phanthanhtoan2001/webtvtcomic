namespace WebAppComics.Models
{
    public class ImageBonus
    {
        public int ImageId { get; set; }

        public string? ImageUrl { get; set; }

        public Guid? ChapterId { get; set; }

        public string? ChapterName { get; set; }
    }
}
