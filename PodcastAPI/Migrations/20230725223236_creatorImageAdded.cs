using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PodcastAPI.Migrations
{
    /// <inheritdoc />
    public partial class creatorImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Creators",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Creators");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Creators");
        }
    }
}
