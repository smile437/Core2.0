using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreApp.DbAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductTypeCode = table.Column<int>(nullable: false),
                    UnitCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "ProductTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitCode",
                        column: x => x.UnitCode,
                        principalTable: "Units",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryCode = table.Column<int>(nullable: false),
                    ProductCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryCode, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "Categories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductCode",
                table: "ProductCategory",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products",
                column: "ProductTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitCode",
                table: "Products",
                column: "UnitCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
