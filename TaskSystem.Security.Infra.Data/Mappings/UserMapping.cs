using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Users.Entities;
using Security.Infra.Data.Extensions;

namespace Security.Infra.Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

            builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

            builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

            builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("varchar(256)");

            builder.Property(e => e.Phone)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("varchar(11)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

        }
    }
}
