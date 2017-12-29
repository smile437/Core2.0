using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreApp.DbAccess.Migrations
{
    public partial class name2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Products_Code",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeCode",
                table: "Products");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Products_Code",
                table: "ProductTypes",
                column: "Code",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
