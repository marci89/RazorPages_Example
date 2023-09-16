using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Business.Models
{
    /// <summary>
    /// Pet types for client
    /// </summary>
    public enum PetTypeViewModel
    {
        [Display(Name = "Cat")]
        Cat = 1,
        [Display(Name = "Dog")]
        Dog = 2,
    }
}
