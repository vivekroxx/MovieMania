using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateByCoulmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c34e3b1-0815-4326-b43d-92dcd2dbdcb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2862b11-8cee-4b5d-9805-9daf7a9707c8");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c34e3b1-0815-4326-b43d-92dcd2dbdcb1", "a3afe8f0-c1b6-487d-9a5c-10e7db05ada1", "Moderator", "MODERATOR" },
                    { "e2862b11-8cee-4b5d-9805-9daf7a9707c8", "59aeefb2-179f-42a3-a042-1dbfdd462528", "Admin", "ADMIN" }
                });
        }
    }
}
