﻿namespace RazorPagesExample.Persistence.Entities
{
	public class User
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime Created { get; set; }
	}
}
