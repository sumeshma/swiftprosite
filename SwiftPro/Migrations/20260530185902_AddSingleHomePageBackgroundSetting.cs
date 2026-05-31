using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddSingleHomePageBackgroundSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseSingleHomePageBackground",
                table: "SiteSettings",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.Sql("""
                UPDATE "SiteSettings"
                SET "UseSingleHomePageBackground" = TRUE
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseSingleHomePageBackground",
                table: "SiteSettings");
        }
    }
}
