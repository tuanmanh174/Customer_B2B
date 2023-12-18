using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerB2B.Repositories.Migrations
{
    public partial class updatedatacompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Companies");
        }
    }
}
