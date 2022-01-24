using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class isActive_and_isDeleted_added_to_task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "task",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "task",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "task");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "task");
        }
    }
}
