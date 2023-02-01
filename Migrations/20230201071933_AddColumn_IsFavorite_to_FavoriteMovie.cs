using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsFavoritetoFavoriteMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Movies");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "FavoriteMovie",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cd82d832-dd67-4232-bde9-b96c7f5ed790");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c397fd00-cec9-4f2b-8794-dd4d03fd5b9d");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "FavoriteMovie");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "35476f9e-bf15-4a0f-bc13-17bdbeb9fa72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6d7fb7e8-84aa-46af-9b6a-d58675d3e036");
        }
    }
}
