using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Profile.Models.Migrations
{
    public partial class AddProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                schema: "mutual",
                table: "Files",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voivodeship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WillToTravelFar = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BackgroundPhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Files_BackgroundPhotoId",
                        column: x => x.BackgroundPhotoId,
                        principalSchema: "mutual",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profiles_Files_ProfilePhotoId",
                        column: x => x.ProfilePhotoId,
                        principalSchema: "mutual",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProfileId",
                schema: "mutual",
                table: "Files",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_BackgroundPhotoId",
                schema: "profile",
                table: "Profiles",
                column: "BackgroundPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfilePhotoId",
                schema: "profile",
                table: "Profiles",
                column: "ProfilePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Profiles_ProfileId",
                schema: "mutual",
                table: "Files",
                column: "ProfileId",
                principalSchema: "profile",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Profiles_ProfileId",
                schema: "mutual",
                table: "Files");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "profile");
        }
    }
}
