using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairID",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "RepairID",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ItemID",
                table: "Repairs",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_OwnerID",
                table: "Repairs",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Owners_OwnerID",
                table: "Repairs",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Owners_OwnerID",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ItemID",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_OwnerID",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "RepairID",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RepairID",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
