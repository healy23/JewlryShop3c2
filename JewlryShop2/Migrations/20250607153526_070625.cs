using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewlryShop2.Migrations
{
    /// <inheritdoc />
    public partial class _070625 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerID",
                table: "Cart",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customers_CustomerID",
                table: "Cart",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customers_CustomerID",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_CustomerID",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Cart");
        }
    }
}
