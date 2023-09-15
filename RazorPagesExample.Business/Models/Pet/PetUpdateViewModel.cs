using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    public class PetUpdateViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "NameRequired")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "AgeRequired")]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}
