using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIImageStoreServer.Migrations
{
    /// <inheritdoc />
    public partial class _140423 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "cart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "cart");
        }
    }
}
