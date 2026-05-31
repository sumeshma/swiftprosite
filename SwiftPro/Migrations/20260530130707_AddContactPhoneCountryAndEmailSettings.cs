using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddContactPhoneCountryAndEmailSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendContactEmails",
                table: "SiteSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SmtpEnableSsl",
                table: "SiteSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SmtpFromEmail",
                table: "SiteSettings",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpHost",
                table: "SiteSettings",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpPassword",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmtpPort",
                table: "SiteSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmtpUsername",
                table: "SiteSettings",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ContactMessages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "ContactMessages",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ContactMessages",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendContactEmails",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpEnableSsl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpFromEmail",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpHost",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpPassword",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpPort",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "SmtpUsername",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ContactMessages");
        }
    }
}
