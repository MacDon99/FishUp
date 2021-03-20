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
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SecurityStamp",
                schema: "identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
