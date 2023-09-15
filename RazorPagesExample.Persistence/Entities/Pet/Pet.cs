namespace RazorPagesExample.Persistence.Entities
{
    /// <summary>
    /// Pet table
    /// </summary>
    public class Pet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public int Age { get; set; }
        public User User { get; set; }
    }
}
