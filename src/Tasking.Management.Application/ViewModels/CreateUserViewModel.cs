﻿namespace Tasking.Management.Application.ViewModels
{
    public class CreateUserViewModel
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}
