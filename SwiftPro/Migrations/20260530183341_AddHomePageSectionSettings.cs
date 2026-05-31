using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddHomePageSectionSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomePageAnchor",
                table: "Pages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePageSortOrder",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomePage",
                table: "Pages",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageAnchor",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "HomePageSortOrder",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ShowOnHomePage",
                table: "Pages");
        }
    }
}
