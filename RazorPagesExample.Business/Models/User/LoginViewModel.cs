using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UsernameRequired")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "UsernameInvalidLength")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }
    }
}