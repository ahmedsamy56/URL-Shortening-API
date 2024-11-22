using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shortening.Migrations
{
    /// <inheritdoc />
    public partial class addShortCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ShortUrls",
                newName: "ShortCode");

            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "ShortUrls");

            migrationBuilder.RenameColumn(
                name: "ShortCode",
                table: "ShortUrls",
                newName: "Url");
        }
    }
}
