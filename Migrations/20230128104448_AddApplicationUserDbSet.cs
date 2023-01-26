using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38bae53e-e90d-471f-8c8c-edcb1c14385a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dde6d9d-bb59-4996-95d5-1f3503a127fa");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e1503da-3eb0-4a6e-a0ea-a3b33efaf77d", "694fffbd-b62d-4007-84e4-54526170468f", "User", "USER" },
                    { "ee08cc35-dcba-4d3d-9c29-ce707de41e9a", "0326b80f-8049-42a9-b64e-a2cd048089d5", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1503da-3eb0-4a6e-a0ea-a3b33efaf77d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee08cc35-dcba-4d3d-9c29-ce707de41e9a");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38bae53e-e90d-471f-8c8c-edcb1c14385a", "019f1df6-10cc-421a-811e-9d53fef77790", "Admin", "ADMIN" },
                    { "6dde6d9d-bb59-4996-95d5-1f3503a127fa", "34b1bdd8-af81-4185-823c-57088794037a", "User", "USER" }
                });
        }
    }
}
