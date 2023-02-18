using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooIS.Server.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RegisteredUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "RegisteredUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "RegisteredUsers");
        }
    }
}
