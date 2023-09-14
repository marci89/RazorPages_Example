using Microsoft.EntityFrameworkCore;
using RazorPagesExample.Persistence;
using RazorPagesExample.Persistence.Entities;

namespace RazorPagesExample.Business.Services
{
	/// <summary>
	/// Managing Users
	/// </summary>
	public class UserService
	{
		private readonly DataContext _dbContext;

		public UserService(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// List user
		/// </summary>
		public async Task<List<User>> ListUser()
		{
			return await _dbContext.Users.ToListAsync();
		}

		/// <summary>
		/// Read user by id
		/// </summary>
		public async Task<User> ReadUserById(long userId)
		{
			return await _dbContext.Users.FindAsync(userId);
		}

		/// <summary>
		/// Create user
		/// </summary>
		public async Task<User> Create(User user)
		{
			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync();
			return user;
		}

		/// <summary>
		/// Update user
		/// </summary>
		public async Task<User> Update(User user)
		{
			_dbContext.Entry(user).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return user;
		}

		/// <summary>
		/// Delete user
		/// </summary>
		public async Task Delete(long userId)
		{
			var user = await _dbContext.Users.FindAsync(userId);
			if (user != null)
			{
				_dbContext.Users.Remove(user);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
