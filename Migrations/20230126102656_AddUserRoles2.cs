using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c81eda-eb69-432b-a9fc-0c595ef0f204");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba1935e4-5900-42d0-91fa-1ac9d0685931");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c34e3b1-0815-4326-b43d-92dcd2dbdcb1", "a3afe8f0-c1b6-487d-9a5c-10e7db05ada1", "Moderator", "MODERATOR" },
                    { "e2862b11-8cee-4b5d-9805-9daf7a9707c8", "59aeefb2-179f-42a3-a042-1dbfdd462528", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c34e3b1-0815-4326-b43d-92dcd2dbdcb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2862b11-8cee-4b5d-9805-9daf7a9707c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86c81eda-eb69-432b-a9fc-0c595ef0f204", "107114fd-d18c-40e6-b43d-652bced43f6c", "Admin", "ADMIN" },
                    { "ba1935e4-5900-42d0-91fa-1ac9d0685931", "a49d47e9-28de-41a5-b565-ee314a8b22eb", "Moderator", "MODERATOR" }
                });
        }
    }
}
