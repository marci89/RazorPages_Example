namespace RazorPagesExample.Persistence.Entities
{
    /// <summary>
    /// User table
    /// </summary>
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
