using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITL_MakeId.Data.Migrations
{
    public partial class Initialwre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "IdentityCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCategorys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCategorys");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "IdentityCards");
        }
    }
}
