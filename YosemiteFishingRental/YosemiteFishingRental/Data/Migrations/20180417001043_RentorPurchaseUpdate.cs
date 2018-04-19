using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace YosemiteFishingRental.Data.Migrations
{
    public partial class RentorPurchaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RentorPurchase",
                table: "Product",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RentorPurchase",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
