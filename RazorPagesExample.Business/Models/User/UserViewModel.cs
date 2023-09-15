namespace RazorPagesExample.Business.Models
{
    /// <summary>
    /// User object for client
    /// </summary>
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }

        public int Age
        {
            get
            {
                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - DateOfBirth.Year;

                if (currentDate < DateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
