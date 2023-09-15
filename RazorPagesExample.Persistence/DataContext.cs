using Microsoft.EntityFrameworkCore;
using RazorPagesExample.Persistence.Entities;

namespace RazorPagesExample.Persistence
{
    /// <summary>
    /// Database context
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Pets)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_Pet_UserId")
                .OnDelete(DeleteBehavior.Cascade);

            #region seeding

            //seed users
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "marci",
                Email = "marci@example.com",
                Password = "marci",
                DateOfBirth = new DateTime(1989, 9, 29),
                Created = DateTime.Now

            },
            new User
            {
                Id = 2,
                Name = "John",
                Email = "john@example.com",
                Password = "john",
                DateOfBirth = new DateTime(1967, 2, 3),
                Created = DateTime.Now
            },
             new User
             {
                 Id = 3,
                 Name = "Alice",
                 Email = "alice@example.com",
                 Password = "alice",
                 DateOfBirth = new DateTime(1990, 5, 15),
                 Created = DateTime.Now
             },
             new User
             {
                 Id = 4,
                 Name = "Eve",
                 Email = "eve@example.com",
                 Password = "eve",
                 DateOfBirth = new DateTime(1985, 11, 8),
                 Created = DateTime.Now
             },
             new User
             {
                 Id = 5,
                 Name = "Grace",
                 Email = "grace@example.com",
                 Password = "grace",
                 DateOfBirth = new DateTime(1992, 7, 21),
                 Created = DateTime.Now
             }
                 );


            // //seed Pets
            modelBuilder.Entity<Pet>().HasData(
                 new Pet
                 {
                     Id = 1,
                     UserId = 1,
                     Name = "Fluffy",
                     Type = PetType.Cat,
                     Age = 4
                 },
                new Pet
                {
                    Id = 2,
                    UserId = 1,
                    Name = "Rover",
                    Type = PetType.Dog,
                    Age = 3
                },
                new Pet
                {
                    Id = 3,
                    UserId = 1,
                    Name = "Whiskers",
                    Type = PetType.Cat,
                    Age = 1
                },
                new Pet
                {
                    Id = 4,
                    UserId = 1,
                    Name = "Fido",
                    Type = PetType.Dog,
                    Age = 6
                },
                new Pet
                {
                    Id = 5,
                    UserId = 1,
                    Name = "Mittens",
                    Type = PetType.Cat,
                    Age = 3
                }
                  );


            #endregion

        }
    }
}
