using System;
using Security.Domain.Core.Models;

namespace Security.Domain.Users.Entities
{
    public class UserRole 
    {
        public Guid IdUser { get; set; }

        public Guid IdRole { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
