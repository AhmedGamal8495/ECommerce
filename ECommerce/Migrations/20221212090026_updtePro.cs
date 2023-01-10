using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class updtePro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_shoppingCarts_ProId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ProId",
                table: "shoppingCarts",
                column: "ProId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_products_ProId",
                table: "shoppingCarts",
                column: "ProId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_products_ProId",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_ProId",
                table: "shoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ProId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProId",
                table: "products",
                column: "ProId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_shoppingCarts_ProId",
                table: "products",
                column: "ProId",
                principalTable: "shoppingCarts",
                principalColumn: "CartId");
        }
    }
}
