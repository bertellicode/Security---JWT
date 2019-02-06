﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Security.Infra.Data.Context;

namespace Security.Infra.Data.Migrations
{
    [DbContext(typeof(SecurityContext))]
    [Migration("20190206171256_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Security.Domain.Users.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("d830ff86-142a-4450-9126-d56f4f7b35f2"), Name = "Admin" },
                        new { Id = new Guid("21ed2c8d-cbfe-465e-9cc1-1af4f5a8d809"), Name = "Test" }
                    );
                });

            modelBuilder.Entity("Security.Domain.Users.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(256);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), Email = "teste@mail.com", Name = "teste", PasswordHash = "123456", Phone = "32991447717", UserName = "teste" }
                    );
                });

            modelBuilder.Entity("Security.Domain.Users.Entities.UserRole", b =>
                {
                    b.Property<Guid>("IdUser");

                    b.Property<Guid>("IdRole");

                    b.HasKey("IdUser", "IdRole");

                    b.HasIndex("IdRole");

                    b.ToTable("UserRole");

                    b.HasData(
                        new { IdUser = new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), IdRole = new Guid("d830ff86-142a-4450-9126-d56f4f7b35f2") },
                        new { IdUser = new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), IdRole = new Guid("21ed2c8d-cbfe-465e-9cc1-1af4f5a8d809") }
                    );
                });

            modelBuilder.Entity("Security.Domain.Users.Entities.UserRole", b =>
                {
                    b.HasOne("Security.Domain.Users.Entities.Role", "Role")
                        .WithMany("UserList")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Security.Domain.Users.Entities.User", "User")
                        .WithMany("RoleList")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}