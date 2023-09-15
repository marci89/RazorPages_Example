using Microsoft.EntityFrameworkCore;
using RazorPagesExample.Business.Models;
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
        private readonly UserFactory _factory;

        public UserService(DataContext dbContext, UserFactory factory)
        {
            _dbContext = dbContext;
            _factory = factory;
        }

        /// <summary>
        /// Login
        /// </summary>
        public async Task<UserViewModel> Login(LoginViewModel request)
        {
            var user = await _dbContext.Users.Where(u => u.Name == request.Username && u.Password == request.Password).FirstOrDefaultAsync();
            return _factory.Create(user);
        }

        /// <summary>
        /// List user
        /// </summary>
        public async Task<List<UserViewModel>> ListUser(long id)
        {
            //filtering the login user
            var users = await _dbContext.Users.Where(u => u.Id != id).ToListAsync();
            return users.Select(u => _factory.Create(u)).ToList();
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
        public async Task<bool> Create(RegistrationViewModel request)
        {
            try
            {
                var user = _factory.Create(request);
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        public async Task<bool> Update(UserUpdateViewModel request)
        {
            try
            {
                var user = await ReadUserById(request.Id);

                _dbContext.Entry(user).State = EntityState.Modified;

                user.Name = request.Username;
                user.Email = request.Email;
                user.DateOfBirth = request.DateOfBirth;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Delete user
        /// </summary>
        public async Task<bool> Delete(long userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
