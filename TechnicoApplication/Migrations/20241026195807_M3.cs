using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Owners_OwnerID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OwnerID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OwnerVAT",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemOwner",
                columns: table => new
                {
                    ItemsID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOwner", x => new { x.ItemsID, x.OwnerID });
                    table.ForeignKey(
                        name: "FK_ItemOwner_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOwner_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOwner_OwnerID",
                table: "ItemOwner",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOwner");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerVAT",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerID",
                table: "Items",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Owners_OwnerID",
                table: "Items",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }
    }
}
