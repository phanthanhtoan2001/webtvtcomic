using System.ComponentModel.DataAnnotations;

namespace WebAppComics.Models
{
    public class ComicBonus
    {
        public Guid ComicId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng không bỏ trống tên truyện!")]
        public string? ComicName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng không bỏ trống mô tả!")]
        public string Describe { get; set; } = null!;

        public string? ComicBanner { get; set; }

        public DateTime? DateSummitted { get; set; }

        public int? Rating { get; set; }

        public string? ComicStatus { get; set; }

        public int AccountId { get; set; }
    }
}
