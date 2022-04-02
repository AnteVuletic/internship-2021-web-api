using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLecture.Data.Migrations
{
    public partial class RenameWronglyNamedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodosItems_Todos_TodoId",
                table: "TodosItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodosItems",
                table: "TodosItems");

            migrationBuilder.RenameTable(
                name: "TodosItems",
                newName: "TodoItems");

            migrationBuilder.RenameIndex(
                name: "IX_TodosItems_TodoId",
                table: "TodoItems",
                newName: "IX_TodoItems_TodoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Todos_TodoId",
                table: "TodoItems",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Todos_TodoId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodosItems");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_TodoId",
                table: "TodosItems",
                newName: "IX_TodosItems_TodoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodosItems",
                table: "TodosItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodosItems_Todos_TodoId",
                table: "TodosItems",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
