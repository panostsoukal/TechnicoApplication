using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicoApplication.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E9Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfConstruction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemOwner",
                columns: table => new
                {
                    ItemsID = table.Column<int>(type: "int", nullable: false),
                    OwnersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOwner", x => new { x.ItemsID, x.OwnersID });
                    table.ForeignKey(
                        name: "FK_ItemOwner_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOwner_Owners_OwnersID",
                        column: x => x.OwnersID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Repairs_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Repairs_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOwner_OwnersID",
                table: "ItemOwner",
                column: "OwnersID");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ItemID",
                table: "Repairs",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_OwnerID",
                table: "Repairs",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOwner");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
