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

		}
	}
}
