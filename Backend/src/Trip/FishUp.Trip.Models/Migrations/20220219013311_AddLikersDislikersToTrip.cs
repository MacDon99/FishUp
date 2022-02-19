using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Trip.Models.Migrations
{
    public partial class AddLikersDislikersToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DislikesCount",
                schema: "trip",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                schema: "trip",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disliker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disliker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disliker_Trips_TripId",
                        column: x => x.TripId,
                        principalSchema: "trip",
                        principalTable: "Trips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Liker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liker_Trips_TripId",
                        column: x => x.TripId,
                        principalSchema: "trip",
                        principalTable: "Trips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disliker_TripId",
                table: "Disliker",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Liker_TripId",
                table: "Liker",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disliker");

            migrationBuilder.DropTable(
                name: "Liker");

            migrationBuilder.DropColumn(
                name: "DislikesCount",
                schema: "trip",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                schema: "trip",
                table: "Trips");
        }
    }
}
