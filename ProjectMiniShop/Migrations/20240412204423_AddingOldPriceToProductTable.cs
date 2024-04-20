using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMiniShop.Migrations
{
    /// <inheritdoc />
    public partial class AddingOldPriceToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "OldPrice",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Products");
        }
    }
}
