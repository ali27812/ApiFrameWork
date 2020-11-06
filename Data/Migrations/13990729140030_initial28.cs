using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionPermissionUserId",
                table: "UserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_PermissionPermissionUserId",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "PermissionPermissionUserId",
                table: "UserPermissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionPermissionUserId",
                table: "UserPermissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionPermissionUserId",
                table: "UserPermissions",
                column: "PermissionPermissionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionPermissionUserId",
                table: "UserPermissions",
                column: "PermissionPermissionUserId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
