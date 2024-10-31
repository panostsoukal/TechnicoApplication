using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ItemID",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "RepairID",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairID",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ItemID",
                table: "Repairs",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
