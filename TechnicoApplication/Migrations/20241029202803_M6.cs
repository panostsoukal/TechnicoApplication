using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerItem_Items_ItemID",
                table: "OwnerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerItem_Owners_OwnerID",
                table: "OwnerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerItem",
                table: "OwnerItem");

            migrationBuilder.RenameTable(
                name: "OwnerItem",
                newName: "OwnerItems");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerItem_OwnerID",
                table: "OwnerItems",
                newName: "IX_OwnerItems_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerItem_ItemID",
                table: "OwnerItems",
                newName: "IX_OwnerItems_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerItems",
                table: "OwnerItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerItems_Items_ItemID",
                table: "OwnerItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerItems_Owners_OwnerID",
                table: "OwnerItems",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerItems_Items_ItemID",
                table: "OwnerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerItems_Owners_OwnerID",
                table: "OwnerItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerItems",
                table: "OwnerItems");

            migrationBuilder.RenameTable(
                name: "OwnerItems",
                newName: "OwnerItem");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerItems_OwnerID",
                table: "OwnerItem",
                newName: "IX_OwnerItem_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerItems_ItemID",
                table: "OwnerItem",
                newName: "IX_OwnerItem_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerItem",
                table: "OwnerItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerItem_Items_ItemID",
                table: "OwnerItem",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerItem_Owners_OwnerID",
                table: "OwnerItem",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }
    }
}
