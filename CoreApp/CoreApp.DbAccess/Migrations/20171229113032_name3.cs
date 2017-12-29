using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreApp.DbAccess.Migrations
{
    public partial class name3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitCode",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Units",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "ProductTypes",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Products_Code",
                table: "ProductTypes",
                column: "Code",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_Code",
                table: "Units",
                column: "Code",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Products_Code",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_Code",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitCode",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Units",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "ProductTypes",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitCode",
                table: "Products",
                column: "UnitCode");
        }
    }
}
