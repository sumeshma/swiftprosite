using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddHeaderFooterSocialSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterBottomText",
                table: "SiteSettings",
                type: "character varying(180)",
                maxLength: 180,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterCompanyHeading",
                table: "SiteSettings",
                type: "character varying(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterCompanyLinksHtml",
                table: "SiteSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterResourcesHeading",
                table: "SiteSettings",
                type: "character varying(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterResourcesLinksHtml",
                table: "SiteSettings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSocialIconsInFooter",
                table: "SiteSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSocialIconsInHeader",
                table: "SiteSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterBottomText",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterCompanyHeading",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterCompanyLinksHtml",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterResourcesHeading",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterResourcesLinksHtml",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ShowSocialIconsInFooter",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ShowSocialIconsInHeader",
                table: "SiteSettings");
        }
    }
}
