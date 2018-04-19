using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YosemiteFishingRental.Data.Migrations
{
    public partial class RentalsAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerFirstName = table.Column<string>(maxLength: 25, nullable: false),
                    CustomerLastName = table.Column<string>(maxLength: 25, nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    RentalPaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rental_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_ProductID",
                table: "Rental",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
