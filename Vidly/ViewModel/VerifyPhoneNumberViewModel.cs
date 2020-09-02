using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "電話號碼")]
        public string PhoneNumber { get; set; }
    }
}