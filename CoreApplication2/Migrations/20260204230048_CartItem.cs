using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreApplication2.Migrations
{
    /// <inheritdoc />
    public partial class CartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoppingTarget",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingTarget", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_shoppingTarget_carTarget_CarId",
                        column: x => x.CarId,
                        principalTable: "carTarget",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingTarget_CarId",
                table: "shoppingTarget",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingTarget");
        }
    }
}
