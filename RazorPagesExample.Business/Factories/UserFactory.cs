﻿using RazorPagesExample.Business.Models;
using RazorPagesExample.Persistence.Entities;

namespace RazorPagesExample.Business
{
    /// <summary>
    /// User object mapping
    /// </summary>
    public class UserFactory
    {
        public virtual UserViewModel Create(User user)
        {
            if (user is null) return null;

            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Created = DateTime.Now
            };
        }
        public virtual User Create(RegistrationViewModel user)
        {
            if (user is null) return null;

            return new User
            {
                Name = user.Username,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                Created = DateTime.Now
            };
        }

    }
}
