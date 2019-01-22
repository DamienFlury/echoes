using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoesServer.Api.Migrations
{
    public partial class DescriptionOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
