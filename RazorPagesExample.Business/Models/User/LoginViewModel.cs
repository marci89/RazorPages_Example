using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
