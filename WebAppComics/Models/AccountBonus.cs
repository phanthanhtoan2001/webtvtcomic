using System.ComponentModel.DataAnnotations;

namespace WebAppComics.Models
{
    public class AccountBonus
    {
        public int AccountId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng không bỏ trống tên tài khoản!\n")]
        public string? AccountName { get; set; }

        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng không bỏ trống tên email!\n")]
        public string? Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng không bỏ trống password!")]
        public string? PassWord { get; set; }

        public int? Phone { get; set; }

        public DateTime? Date { get; set; }

        public string? AccountImage { get; set; }

        public int CategoryAccId { get; set; }
    }
}
