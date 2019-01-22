using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Users.Entities;
using Security.Infra.Data.Extensions;

namespace Security.Infra.Data.Mappings
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public override void Map(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");

            builder
                .HasKey(pc => new { pc.IdUser, pc.IdRole });

            builder
                .HasOne(pt => pt.User)
                .WithMany(p => p.RoleList)
                .HasForeignKey(pt => pt.IdUser);

            builder
                .HasOne(pt => pt.Role)
                .WithMany(p => p.UserList)
                .HasForeignKey(pt => pt.IdRole);
        }
    }
}
