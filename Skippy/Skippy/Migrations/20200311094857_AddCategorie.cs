using Microsoft.EntityFrameworkCore.Migrations;

namespace Skippy.Migrations
{
    public partial class AddCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 100, nullable: false),
                    CategorieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorie_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategorieId",
                table: "Product",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_CategorieId",
                table: "Categorie",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categorie_CategorieId",
                table: "Product",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categorie_CategorieId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategorieId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Product");
        }
    }
}
