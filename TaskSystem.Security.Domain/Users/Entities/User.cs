using System.Collections.Generic;
using Security.Domain.Core.Models;

namespace Security.Domain.Users.Entities
{
    public class User : Entity<User>
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<UserRole> RoleList { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
