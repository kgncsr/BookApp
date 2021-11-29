using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.DataAccess.Migrations
{
    public partial class AddContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writers_WriterId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writers",
                table: "Writers");

            migrationBuilder.RenameTable(
                name: "Writers",
                newName: "Writer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writer",
                table: "Writer",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writer_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Writer",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writer_WriterId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writer",
                table: "Writer");

            migrationBuilder.RenameTable(
                name: "Writer",
                newName: "Writers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writers",
                table: "Writers",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writers_WriterId",
                table: "Books",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
