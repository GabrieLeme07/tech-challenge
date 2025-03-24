using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class CreatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MinQuantity = table.Column<int>(type: "integer", nullable: false),
                    MaxQuantity = table.Column<int>(type: "integer", nullable: true),
                    Percentage = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Rate = table.Column<float>(type: "real", precision: 3, scale: 2, nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleNumber = table.Column<string>(type: "text", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    BranchId = table.Column<string>(type: "text", nullable: false),
                    BranchName = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RatingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Cancelled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_Id",
                        column: x => x.Id,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "IsActive", "MaxQuantity", "MinQuantity", "Percentage" },
                values: new object[,]
                {
                    { new Guid("637c75ab-12d4-4dab-9e7e-a32a81752f44"), true, 20, 10, 20m },
                    { new Guid("80944d57-50ea-492a-9378-27ee5673c946"), true, 9, 4, 10m }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Count", "Rate" },
                values: new object[,]
                {
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d"), 10, 5f },
                    { new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e"), 10, 5f }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Image", "Price", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000001"), "Eletronicos", "eletronico1.jpg", 1200.00m, 20, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000001"), "Smartphone Eletronico 1" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000002"), "Eletronicos", "eletronico2.jpg", 1300.00m, 18, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000002"), "Smartphone Eletronico 2" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000003"), "Eletronicos", "eletronico3.jpg", 2500.00m, 10, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000003"), "Smart TV Eletronico 3" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000004"), "Eletronicos", "eletronico4.jpg", 3000.00m, 8, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000004"), "Notebook Eletronico 4" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000005"), "Eletronicos", "eletronico5.jpg", 900.00m, 12, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000005"), "Tablet Eletronico 5" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000006"), "Eletronicos", "eletronico6.jpg", 1500.00m, 5, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000006"), "Câmera Eletronico 6" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000007"), "Eletronicos", "eletronico7.jpg", 200.00m, 25, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000007"), "Fone de Ouvido Eletronico 7" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000008"), "Eletronicos", "eletronico8.jpg", 350.00m, 30, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000008"), "Smartwatch Eletronico 8" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000009"), "Eletronicos", "eletronico9.jpg", 2800.00m, 7, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000009"), "Console Eletronico 9" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000a"), "Eletronicos", "eletronico10.jpg", 800.00m, 10, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000a"), "Monitor Eletronico 10" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000b"), "Bebidas", "bebida1.jpg", 5.00m, 50, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000b"), "Refrigerante Bebida 1" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000c"), "Bebidas", "bebida2.jpg", 5.50m, 60, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000c"), "Refrigerante Bebida 2" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000d"), "Bebidas", "bebida3.jpg", 8.00m, 40, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000d"), "Suco Bebida 3" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000e"), "Bebidas", "bebida4.jpg", 10.00m, 100, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000e"), "Cerveja Bebida 4" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000000f"), "Bebidas", "bebida5.jpg", 50.00m, 30, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000000f"), "Vinho Bebida 5" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000010"), "Bebidas", "bebida6.jpg", 2.00m, 80, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000010"), "Água Bebida 6" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000011"), "Bebidas", "bebida7.jpg", 7.50m, 35, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000011"), "Suco Bebida 7" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000012"), "Bebidas", "bebida8.jpg", 6.00m, 55, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000012"), "Refrigerante Bebida 8" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000013"), "Bebidas", "bebida9.jpg", 12.00m, 90, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000013"), "Cerveja Bebida 9" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000014"), "Bebidas", "bebida10.jpg", 2.50m, 70, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000014"), "Água Bebida 10" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000015"), "Decoração", "decoracao1.jpg", 45.00m, 15, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000015"), "Vaso Decoracao 1" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000016"), "Decoração", "decoracao2.jpg", 55.00m, 20, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000016"), "Vaso Decoracao 2" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000017"), "Decoração", "decoracao3.jpg", 120.00m, 10, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000017"), "Quadro Decoracao 3" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000018"), "Decoração", "decoracao4.jpg", 150.00m, 8, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000018"), "Relógio Decoracao 4" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-000000000019"), "Decoração", "decoracao5.jpg", 80.00m, 12, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-000000000019"), "Luminária Decoracao 5" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001a"), "Decoração", "decoracao6.jpg", 35.00m, 30, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001a"), "Almofada Decoracao 6" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001b"), "Decoração", "decoracao7.jpg", 200.00m, 5, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001b"), "Espelho Decoracao 7" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001c"), "Decoração", "decoracao8.jpg", 100.00m, 7, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001c"), "Cortina Decoracao 8" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001d"), "Decoração", "decoracao9.jpg", 750.00m, 3, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001d"), "Sofá Decoracao 9" },
                    { new Guid("d1a8d8a7-0e2b-4b6d-9e5c-00000000001e"), "Decoração", "decoracao10.jpg", 350.00m, 4, new Guid("f1a8d8a7-0e2b-4b6d-9e5c-00000000001e"), "Mesa Decoracao 10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartId",
                table: "CartProducts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RatingId",
                table: "Products",
                column: "RatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
