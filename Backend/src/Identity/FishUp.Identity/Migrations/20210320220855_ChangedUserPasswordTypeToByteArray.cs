using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishUp.Identity.Migrations
{
    public partial class ChangedUserPasswordTypeToByteArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SecurityStamp",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
