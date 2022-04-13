using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipToAddress_ZipCode",
                table: "Orders",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_Street",
                table: "Orders",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_State",
                table: "Orders",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_LastName",
                table: "Orders",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_FirstName",
                table: "Orders",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_City",
                table: "Orders",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Orders",
                newName: "ShipToAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Orders",
                newName: "ShipToAddress_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Orders",
                newName: "ShipToAddress_State");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Orders",
                newName: "ShipToAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Orders",
                newName: "ShipToAddress_FirstName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Orders",
                newName: "ShipToAddress_City");
        }
    }
}
