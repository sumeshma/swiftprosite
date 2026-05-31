using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPro.Migrations
{
    /// <inheritdoc />
    public partial class AddContactInboxWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppNumber",
                table: "SiteSettings",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XUrl",
                table: "SiteSettings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminNotes",
                table: "ContactMessages",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ContactMessages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRepliedAt",
                table: "ContactMessages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastReplyChannel",
                table: "ContactMessages",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ContactMessages",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "WhatsAppNumber",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "XUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "AdminNotes",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "LastRepliedAt",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "LastReplyChannel",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContactMessages");
        }
    }
}
