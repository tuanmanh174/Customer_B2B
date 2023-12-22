using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerB2B.Repositories.Migrations
{
    public partial class UpdatefieldStatustableCooperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "CompanyCopperationInformations",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompanyCopperationInformations");
        }
    }
}
