

namespace RazorPagesExample.Business.Models
{
    public class PetViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public PetTypeViewModel Type { get; set; }
        public int Age { get; set; }
    }
}
