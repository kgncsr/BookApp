using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.DataAccess.Migrations
{
    public partial class BookVoteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(168)",
                oldMaxLength: 168);

            migrationBuilder.AddColumn<decimal>(
                name: "Vote",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(168)",
                maxLength: 168,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
