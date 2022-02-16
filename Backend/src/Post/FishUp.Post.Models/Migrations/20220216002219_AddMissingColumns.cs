using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Post.Models.Migrations
{
    public partial class AddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "post",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "post",
                table: "Likers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "mutual",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "post",
                table: "Dislikers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "post",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "post",
                table: "Likers");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "mutual",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "post",
                table: "Dislikers");
        }
    }
}
