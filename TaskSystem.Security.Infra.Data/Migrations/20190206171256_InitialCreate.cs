using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    IdRole = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.IdUser, x.IdRole });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d830ff86-142a-4450-9126-d56f4f7b35f2"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("21ed2c8d-cbfe-465e-9cc1-1af4f5a8d809"), "Test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Phone", "UserName" },
                values: new object[] { new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), "teste@mail.com", "teste", "123456", "32991447717", "teste" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "IdUser", "IdRole" },
                values: new object[] { new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), new Guid("d830ff86-142a-4450-9126-d56f4f7b35f2") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "IdUser", "IdRole" },
                values: new object[] { new Guid("480e303e-dadb-40d8-b7db-0a7ce77b6fbf"), new Guid("21ed2c8d-cbfe-465e-9cc1-1af4f5a8d809") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_IdRole",
                table: "UserRole",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
