using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Trip.Models.Migrations
{
    public partial class ChangesInTripEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mutual");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "trip",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TripId",
                schema: "mutual",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "trip",
                table: "Participants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "mutual",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Trips_TripId",
                schema: "trip",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "trip",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "trip",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TripID",
                schema: "trip",
                table: "Trips");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Trips_TripId",
                schema: "trip",
                table: "Participants",
                column: "TripId",
                principalSchema: "trip",
                principalTable: "Trips",
                principalColumn: "Id");
        }
    }
}
