using System.ComponentModel.DataAnnotations;

namespace WebAppComics.Models
{
    public class ChapterBonus
    {
        public Guid ChapterId { get; set; }

        public string? ChapterName { get; set; }

        public int? View { get; set; }

     
        public DateTime? UpdateDay { get; set; }

        public Guid? ComicId { get; set; }
    }
}
