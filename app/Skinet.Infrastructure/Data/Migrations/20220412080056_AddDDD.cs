using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddDDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductBrands");

            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ProductName",
                table: "OrderItems",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ProductItemId",
                table: "OrderItems",
                newName: "ProductItemId");

            migrationBuilder.RenameColumn(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                newName: "PictureUrl");

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "OrderItems",
                newName: "ItemOrdered_ProductName");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "OrderItems",
                newName: "ItemOrdered_ProductItemId");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "OrderItems",
                newName: "ItemOrdered_PictureUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
