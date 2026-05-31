using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddHomePageSectionTransparency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomePageSectionTransparency",
                table: "SiteSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageSectionTransparency",
                table: "SiteSettings");
        }
    }
}
