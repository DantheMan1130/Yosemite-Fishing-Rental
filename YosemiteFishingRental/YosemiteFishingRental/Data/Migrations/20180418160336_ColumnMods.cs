using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YosemiteFishingRental.Data.Migrations
{
    public partial class ColumnMods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Rental",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentorPurchase",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Rental");

            migrationBuilder.AlterColumn<string>(
                name: "RentorPurchase",
                table: "Product",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
