using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShopPhoneItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopPhoneItem",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopPhoneItem");
        }
    }
}
