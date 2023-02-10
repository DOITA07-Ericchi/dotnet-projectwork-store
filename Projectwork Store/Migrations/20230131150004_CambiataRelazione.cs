using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectworkStore.Migrations
{
    /// <inheritdoc />
    public partial class CambiataRelazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_SupplierPurchases_SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_UserPurchases_UserPurchaseId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserPurchaseId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SupplierPurchaseId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserPurchaseId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "PurchaseData",
                table: "UserPurchases",
                newName: "PurchaseDate");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "UserPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "SupplierPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserPurchases_CarId",
                table: "UserPurchases",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPurchases_CarId",
                table: "SupplierPurchases",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPurchases_Cars_CarId",
                table: "SupplierPurchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPurchases_Cars_CarId",
                table: "UserPurchases",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPurchases_Cars_CarId",
                table: "SupplierPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPurchases_Cars_CarId",
                table: "UserPurchases");

            migrationBuilder.DropIndex(
                name: "IX_UserPurchases_CarId",
                table: "UserPurchases");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPurchases_CarId",
                table: "SupplierPurchases");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "UserPurchases");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "SupplierPurchases");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "UserPurchases",
                newName: "PurchaseData");

            migrationBuilder.AddColumn<int>(
                name: "SupplierPurchaseId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserPurchaseId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SupplierPurchaseId",
                table: "Cars",
                column: "SupplierPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserPurchaseId",
                table: "Cars",
                column: "UserPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_SupplierPurchases_SupplierPurchaseId",
                table: "Cars",
                column: "SupplierPurchaseId",
                principalTable: "SupplierPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_UserPurchases_UserPurchaseId",
                table: "Cars",
                column: "UserPurchaseId",
                principalTable: "UserPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
