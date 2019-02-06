using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Security.Domain.Users.Entities;
using Security.Infra.Data.Extensions;
using Security.Infra.Data.Mappings;

namespace Security.Infra.Data.Context
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UserMapping());

            modelBuilder.AddConfiguration(new RoleMapping());

            modelBuilder.AddConfiguration(new UserRoleMapping());

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var userGuid = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userGuid,
                UserName = "teste",
                Name = "teste",
                PasswordHash = "123456",
                Email = "teste@mail.com",
                Phone = "32991447717"
            });

            var roleGuid1 = Guid.NewGuid();
            var roleGuid2 = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleGuid1,
                Name = "Admin"
            }, new Role
            {
                Id = roleGuid2,
                Name = "Test"
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                IdUser = userGuid,
                IdRole = roleGuid1
            }, new UserRole
            {
                IdUser = userGuid,
                IdRole = roleGuid2
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
