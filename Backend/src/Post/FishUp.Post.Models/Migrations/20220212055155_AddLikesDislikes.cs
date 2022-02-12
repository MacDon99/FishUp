using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Post.Models.Migrations
{
    public partial class AddLikesDislikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Dislikers",
                schema: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dislikers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dislikers_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likers",
                schema: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likers_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dislikers_PostId",
                schema: "post",
                table: "Dislikers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likers_PostId",
                schema: "post",
                table: "Likers",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dislikers",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Likers",
                schema: "post");
        }
    }
}
