using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseOrder.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMaterial",
                columns: table => new
                {
                    matID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matRef = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    matDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    matUOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    matStandardCost = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaterial", x => x.matID);
                });

            migrationBuilder.CreateTable(
                name: "tblVendor",
                columns: table => new
                {
                    vendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtAccNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VATNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VATPerc = table.Column<decimal>(type: "decimal(6,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVendor", x => x.vendorID);
                });

            migrationBuilder.CreateTable(
                name: "tblPurHeader",
                columns: table => new
                {
                    purHeaderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vendorID = table.Column<int>(type: "int", nullable: false),
                    purCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    purExpectedArrivalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    purSourceReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    purAmountExclVAT = table.Column<decimal>(type: "money", nullable: true),
                    purAmountVAT = table.Column<decimal>(type: "money", nullable: true),
                    purAmountInclVAT = table.Column<decimal>(type: "money", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurHeader", x => x.purHeaderID);
                    table.ForeignKey(
                        name: "FK_tblPurHeader_tblVendor",
                        column: x => x.vendorID,
                        principalTable: "tblVendor",
                        principalColumn: "vendorID");
                });

            migrationBuilder.CreateTable(
                name: "tblPurDetail",
                columns: table => new
                {
                    purDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purHeaderID = table.Column<int>(type: "int", nullable: false),
                    purMatID = table.Column<int>(type: "int", nullable: false),
                    purExpectedArrivalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    purQty = table.Column<int>(type: "int", nullable: false),
                    purUoM = table.Column<int>(type: "int", nullable: true),
                    purUnitPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    purAmountExclVAT = table.Column<decimal>(type: "money", nullable: true),
                    purAmountVAT = table.Column<decimal>(type: "money", nullable: true),
                    purAmountInclVAT = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurDetail", x => x.purDetailID);
                    table.ForeignKey(
                        name: "FK_tblPurDetail_tblMaterial",
                        column: x => x.purMatID,
                        principalTable: "tblMaterial",
                        principalColumn: "matID");
                    table.ForeignKey(
                        name: "FK_tblPurDetail_tblPurHeader",
                        column: x => x.purHeaderID,
                        principalTable: "tblPurHeader",
                        principalColumn: "purHeaderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPurDetail_purHeaderID",
                table: "tblPurDetail",
                column: "purHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurDetail_purMatID",
                table: "tblPurDetail",
                column: "purMatID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurHeader_vendorID",
                table: "tblPurHeader",
                column: "vendorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPurDetail");

            migrationBuilder.DropTable(
                name: "tblMaterial");

            migrationBuilder.DropTable(
                name: "tblPurHeader");

            migrationBuilder.DropTable(
                name: "tblVendor");
        }
    }
}
