using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RatingId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: true),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, true, 9, 4, 10m },
                    { 2, true, 20, 10, 20m }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Count", "Rate" },
                values: new object[,]
                {
                    { 1, 10, 5f },
                    { 2, 10, 5f },
                    { 3, 10, 5f },
                    { 4, 10, 5f },
                    { 5, 10, 5f },
                    { 6, 10, 5f },
                    { 7, 10, 5f },
                    { 8, 10, 5f },
                    { 9, 10, 5f },
                    { 10, 10, 5f },
                    { 11, 10, 5f },
                    { 12, 10, 5f },
                    { 13, 10, 5f },
                    { 14, 10, 5f },
                    { 15, 10, 5f },
                    { 16, 10, 5f },
                    { 17, 10, 5f },
                    { 18, 10, 5f },
                    { 19, 10, 5f },
                    { 20, 10, 5f },
                    { 21, 10, 5f },
                    { 22, 10, 5f },
                    { 23, 10, 5f },
                    { 24, 10, 5f },
                    { 25, 10, 5f },
                    { 26, 10, 5f },
                    { 27, 10, 5f },
                    { 28, 10, 5f },
                    { 29, 10, 5f },
                    { 30, 10, 5f }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Image", "Price", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { 1, "Eletronicos", "eletronico1.jpg", 1200.00m, 20, 1, "Smartphone Eletronico 1" },
                    { 2, "Eletronicos", "eletronico2.jpg", 1300.00m, 18, 2, "Smartphone Eletronico 2" },
                    { 3, "Eletronicos", "eletronico3.jpg", 2500.00m, 10, 3, "Smart TV Eletronico 3" },
                    { 4, "Eletronicos", "eletronico4.jpg", 3000.00m, 8, 4, "Notebook Eletronico 4" },
                    { 5, "Eletronicos", "eletronico5.jpg", 900.00m, 12, 5, "Tablet Eletronico 5" },
                    { 6, "Eletronicos", "eletronico6.jpg", 1500.00m, 5, 6, "Câmera Eletronico 6" },
                    { 7, "Eletronicos", "eletronico7.jpg", 200.00m, 25, 7, "Fone de Ouvido Eletronico 7" },
                    { 8, "Eletronicos", "eletronico8.jpg", 350.00m, 30, 8, "Smartwatch Eletronico 8" },
                    { 9, "Eletronicos", "eletronico9.jpg", 2800.00m, 7, 9, "Console Eletronico 9" },
                    { 10, "Eletronicos", "eletronico10.jpg", 800.00m, 10, 10, "Monitor Eletronico 10" },
                    { 11, "Bebidas", "bebida1.jpg", 5.00m, 50, 11, "Refrigerante Bebida 1" },
                    { 12, "Bebidas", "bebida2.jpg", 5.50m, 60, 12, "Refrigerante Bebida 2" },
                    { 13, "Bebidas", "bebida3.jpg", 8.00m, 40, 13, "Suco Bebida 3" },
                    { 14, "Bebidas", "bebida4.jpg", 10.00m, 100, 14, "Cerveja Bebida 4" },
                    { 15, "Bebidas", "bebida5.jpg", 50.00m, 30, 15, "Vinho Bebida 5" },
                    { 16, "Bebidas", "bebida6.jpg", 2.00m, 80, 16, "Água Bebida 6" },
                    { 17, "Bebidas", "bebida7.jpg", 7.50m, 35, 17, "Suco Bebida 7" },
                    { 18, "Bebidas", "bebida8.jpg", 6.00m, 55, 18, "Refrigerante Bebida 8" },
                    { 19, "Bebidas", "bebida9.jpg", 12.00m, 90, 19, "Cerveja Bebida 9" },
                    { 20, "Bebidas", "bebida10.jpg", 2.50m, 70, 20, "Água Bebida 10" },
                    { 21, "Decoração", "decoracao2.jpg", 55.00m, 20, 22, "Vaso Decoracao 2" },
                    { 22, "Decoração", "decoracao3.jpg", 120.00m, 10, 23, "Quadro Decoracao 3" },
                    { 23, "Decoração", "decoracao4.jpg", 150.00m, 8, 24, "Relógio Decoracao 4" },
                    { 24, "Decoração", "decoracao5.jpg", 80.00m, 12, 25, "Luminária Decoracao 5" },
                    { 25, "Decoração", "decoracao6.jpg", 35.00m, 30, 26, "Almofada Decoracao 6" },
                    { 26, "Decoração", "decoracao7.jpg", 200.00m, 5, 27, "Espelho Decoracao 7" },
                    { 27, "Decoração", "decoracao8.jpg", 100.00m, 7, 28, "Cortina Decoracao 8" },
                    { 28, "Decoração", "decoracao9.jpg", 750.00m, 3, 29, "Sofá Decoracao 9" },
                    { 29, "Decoração", "decoracao10.jpg", 350.00m, 4, 30, "Mesa Decoracao 10" },
                    { 30, "Decoração", "decoracao1.jpg", 45.00m, 15, 21, "Vaso Decoracao 1" }
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
