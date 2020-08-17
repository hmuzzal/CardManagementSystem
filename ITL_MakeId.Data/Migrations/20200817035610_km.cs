using Microsoft.EntityFrameworkCore.Migrations;

namespace ITL_MakeId.Data.Migrations
{
    public partial class km : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CardCategorys",
                table: "CardCategorys");

            migrationBuilder.RenameTable(
                name: "CardCategorys",
                newName: "CardCategories");

            migrationBuilder.AddColumn<int>(
                name: "CardCategoryId",
                table: "IdentityCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardCategories",
                table: "CardCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCards_CardCategoryId",
                table: "IdentityCards",
                column: "CardCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_CardCategories_CardCategoryId",
                table: "IdentityCards",
                column: "CardCategoryId",
                principalTable: "CardCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_CardCategories_CardCategoryId",
                table: "IdentityCards");

            migrationBuilder.DropIndex(
                name: "IX_IdentityCards_CardCategoryId",
                table: "IdentityCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardCategories",
                table: "CardCategories");

            migrationBuilder.DropColumn(
                name: "CardCategoryId",
                table: "IdentityCards");

            migrationBuilder.RenameTable(
                name: "CardCategories",
                newName: "CardCategorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardCategorys",
                table: "CardCategorys",
                column: "Id");
        }
    }
}
