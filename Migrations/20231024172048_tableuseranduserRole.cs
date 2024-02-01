using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEFbyMigration.Migrations
{
    public partial class tableuseranduserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "userRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_userRoleId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "userRoleId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserRoles",
                newName: "userRoleName");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users",
                column: "userRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userRoleId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userRoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "userRoleName",
                table: "UserRoles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "userRoleId",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
