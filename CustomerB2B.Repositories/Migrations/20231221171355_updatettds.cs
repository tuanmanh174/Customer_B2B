using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerB2B.Repositories.Migrations
{
    public partial class updatettds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CompanyRepresentatives");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyRepresentatives");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyRepresentatives");

            migrationBuilder.DropColumn(
                name: "Notice",
                table: "CompanyRepresentatives");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CompanyRepresentatives");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CompanyRepresentatives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CompanyRepresentatives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CompanyRepresentatives",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyRepresentatives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notice",
                table: "CompanyRepresentatives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CompanyRepresentatives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CompanyRepresentatives",
                type: "datetime2",
                nullable: true);
        }
    }
}
