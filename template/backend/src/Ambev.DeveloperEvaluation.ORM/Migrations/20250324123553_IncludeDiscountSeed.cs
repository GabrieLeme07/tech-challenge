using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class IncludeDiscountSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "IsActive", "MaxQuantity", "MinQuantity", "Percentage" },
                values: new object[,]
                {
                    { new Guid("637c75ab-12d4-4dab-9e7e-a32a81752f44"), true, 20, 10, 20m },
                    { new Guid("80944d57-50ea-492a-9378-27ee5673c946"), true, 9, 4, 10m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("637c75ab-12d4-4dab-9e7e-a32a81752f44"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("80944d57-50ea-492a-9378-27ee5673c946"));
        }
    }
}
