using System.Collections.Generic;
using Security.Domain.Core.Models;

namespace Security.Domain.Users.Entities
{
    public class Role : Entity<User>
    {
        public string Name { get; set; }

        public ICollection<UserRole> UserList { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
