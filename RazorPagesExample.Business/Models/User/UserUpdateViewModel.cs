using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    /// <summary>
    /// Model for update user view and action
    /// </summary>
    public class UserUpdateViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "UsernameRequired")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "UsernameInvalidLength")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "EmailRequired")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "InvalidEmailFormat")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DateOfBirthRequired")]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }
    }
}
