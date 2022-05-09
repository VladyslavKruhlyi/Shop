using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShopCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopPhoneItem");

            migrationBuilder.CreateTable(
                name: "ShopCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ShopPhoneId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItem_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_PhoneId",
                table: "ShopCartItem",
                column: "PhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItem");

            migrationBuilder.CreateTable(
                name: "ShopPhoneItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShopPhoneId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopPhoneItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopPhoneItem_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopPhoneItem_PhoneId",
                table: "ShopPhoneItem",
                column: "PhoneId");
        }
    }
}
