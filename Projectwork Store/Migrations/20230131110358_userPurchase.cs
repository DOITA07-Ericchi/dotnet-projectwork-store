using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectworkStore.Migrations
{
    /// <inheritdoc />
    public partial class userPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPurchaseId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPurchases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserPurchaseId",
                table: "Cars",
                column: "UserPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_UserPurchases_UserPurchaseId",
                table: "Cars",
                column: "UserPurchaseId",
                principalTable: "UserPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_UserPurchases_UserPurchaseId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "UserPurchases");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserPurchaseId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserPurchaseId",
                table: "Cars");
        }
    }
}
