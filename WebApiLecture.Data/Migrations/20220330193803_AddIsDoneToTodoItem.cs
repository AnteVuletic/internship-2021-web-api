using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLecture.Data.Migrations
{
    public partial class AddIsDoneToTodoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "TodosItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "TodosItems");
        }
    }
}
