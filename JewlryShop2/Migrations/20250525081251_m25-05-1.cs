using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewlryShop2.Migrations
{
    /// <inheritdoc />
    public partial class m25051 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelrys_Purchases_PurchaseID",
                table: "Jewelrys");

            migrationBuilder.DropTable(
                name: "JewelryInPurchases");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Jewelrys_PurchaseID",
                table: "Jewelrys");

            migrationBuilder.DropColumn(
                name: "PurchaseID",
                table: "Jewelrys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseID",
                table: "Jewelrys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchases_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JewelryInPurchases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryID = table.Column<int>(type: "int", nullable: false),
                    PurchaseID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryInPurchases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JewelryInPurchases_Jewelrys_JewelryID",
                        column: x => x.JewelryID,
                        principalTable: "Jewelrys",
                        principalColumn: "JewelryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JewelryInPurchases_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jewelrys_PurchaseID",
                table: "Jewelrys",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryInPurchases_JewelryID",
                table: "JewelryInPurchases",
                column: "JewelryID");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryInPurchases_PurchaseID",
                table: "JewelryInPurchases",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerID",
                table: "Purchases",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelrys_Purchases_PurchaseID",
                table: "Jewelrys",
                column: "PurchaseID",
                principalTable: "Purchases",
                principalColumn: "ID");
        }
    }
}
