using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEFbyMigration.Migrations
{
    public partial class tablerole5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userRoleId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userRoleId",
                table: "Users",
                column: "userRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users",
                column: "userRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
