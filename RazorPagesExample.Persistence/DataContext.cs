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

		public DataContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//seed user
			modelBuilder.Entity<User>().HasData(
		  new User
		  {
			  Id = 1,
			  Name = "user",
			  Email = "user@example.com",
			  Password = "user",
			  DateOfBirth = new DateTime(1989, 9, 29),
			  Created = DateTime.Now
		  }
		);



		}
	}
}
