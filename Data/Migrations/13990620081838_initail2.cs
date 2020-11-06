using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desc",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "Users",
                nullable: true);
        }
    }
}
