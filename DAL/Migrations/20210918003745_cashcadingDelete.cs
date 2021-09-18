using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class cashcadingDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Country",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer",
                table: "CustomerAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Country",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Country",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer",
                table: "CustomerAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Country",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
