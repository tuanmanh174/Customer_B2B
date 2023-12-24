using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerB2B.Repositories.Migrations
{
    public partial class UpdateDBBc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "Notice",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CompanyDocuments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CompanyDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CompanyDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyDocuments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notice",
                table: "CompanyDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CompanyDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CompanyDocuments",
                type: "datetime2",
                nullable: true);
        }
    }
}
