using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    /// <summary>
    /// Model for registration view and action
    /// </summary>
    public class RegistrationViewModel
    {
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
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [Compare("Password", ErrorMessage = "PasswordNotMatch")]
        public string ConfirmPassword { get; set; }
    }
}
