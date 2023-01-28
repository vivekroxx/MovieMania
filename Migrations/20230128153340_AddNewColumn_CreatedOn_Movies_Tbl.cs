using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnCreatedOnMoviesTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1503da-3eb0-4a6e-a0ea-a3b33efaf77d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee08cc35-dcba-4d3d-9c29-ce707de41e9a");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30f5cc8e-ba5f-4c9f-9f36-71de4d14053d", "538ece64-824f-46fb-8b33-594dbcdec514", "Admin", "ADMIN" },
                    { "dae04e7c-3571-4e67-888e-985b995de016", "780f39dc-b18f-4bae-88d1-b61a5d88b8cc", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30f5cc8e-ba5f-4c9f-9f36-71de4d14053d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae04e7c-3571-4e67-888e-985b995de016");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e1503da-3eb0-4a6e-a0ea-a3b33efaf77d", "694fffbd-b62d-4007-84e4-54526170468f", "User", "USER" },
                    { "ee08cc35-dcba-4d3d-9c29-ce707de41e9a", "0326b80f-8049-42a9-b64e-a2cd048089d5", "Admin", "ADMIN" }
                });
        }
    }
}
