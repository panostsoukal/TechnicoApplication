using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Owners_OwnerID",
                table: "Repairs");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Repairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Items_ItemID",
                table: "Repairs",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Owners_OwnerID",
                table: "Repairs",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }
    }
}
