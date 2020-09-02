using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "電話號碼")]
        public string Number { get; set; }
    }
}