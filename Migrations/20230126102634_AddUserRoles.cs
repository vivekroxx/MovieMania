using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86c81eda-eb69-432b-a9fc-0c595ef0f204", "107114fd-d18c-40e6-b43d-652bced43f6c", "Admin", "ADMIN" },
                    { "ba1935e4-5900-42d0-91fa-1ac9d0685931", "a49d47e9-28de-41a5-b565-ee314a8b22eb", "Moderator", "MODERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c81eda-eb69-432b-a9fc-0c595ef0f204");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba1935e4-5900-42d0-91fa-1ac9d0685931");
        }
    }
}
