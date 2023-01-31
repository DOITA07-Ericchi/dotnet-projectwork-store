using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectworkStore.Migrations
{
    /// <inheritdoc />
    public partial class nm2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserPurchases",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "SupplierPurchaseId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SupplierPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPurchases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SupplierPurchaseId",
                table: "Cars",
                column: "SupplierPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_SupplierPurchases_SupplierPurchaseId",
                table: "Cars",
                column: "SupplierPurchaseId",
                principalTable: "SupplierPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_SupplierPurchases_SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "SupplierPurchases");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserPurchases",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
