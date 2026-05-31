using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaLibraryAndImageSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultThumbnailUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaviconUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterLogoUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterLogoWidth",
                table: "SiteSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeaderLogoWidth",
                table: "SiteSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MediaAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    UsageType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AltText = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    OriginalFileName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAssets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "DefaultThumbnailUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FaviconUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterLogoUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FooterLogoWidth",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "HeaderLogoWidth",
                table: "SiteSettings");
        }
    }
}
