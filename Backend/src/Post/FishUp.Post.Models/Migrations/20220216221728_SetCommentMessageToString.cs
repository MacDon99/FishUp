using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Post.Models.Migrations
{
    public partial class SetCommentMessageToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Message",
                schema: "mutual",
                table: "Comments",
                type: "varchar(max)",
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "mutual",
                table: "Comments",
                type: "int",
                oldType: "varchar(max)");
        }
    }
}
