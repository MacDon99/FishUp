using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishUp.Profile.Models.Migrations
{
    public partial class SedProfileAndBackgroundPhotosAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Files_BackgroundPhotoId",
                schema: "profile",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Files_ProfilePhotoId",
                schema: "profile",
                table: "Profiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePhotoId",
                schema: "profile",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BackgroundPhotoId",
                schema: "profile",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Files_BackgroundPhotoId",
                schema: "profile",
                table: "Profiles",
                column: "BackgroundPhotoId",
                principalSchema: "mutual",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Files_ProfilePhotoId",
                schema: "profile",
                table: "Profiles",
                column: "ProfilePhotoId",
                principalSchema: "mutual",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Files_BackgroundPhotoId",
                schema: "profile",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Files_ProfilePhotoId",
                schema: "profile",
                table: "Profiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePhotoId",
                schema: "profile",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BackgroundPhotoId",
                schema: "profile",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Files_BackgroundPhotoId",
                schema: "profile",
                table: "Profiles",
                column: "BackgroundPhotoId",
                principalSchema: "mutual",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Files_ProfilePhotoId",
                schema: "profile",
                table: "Profiles",
                column: "ProfilePhotoId",
                principalSchema: "mutual",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
