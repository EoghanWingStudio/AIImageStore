using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIImageStoreServer.Migrations
{
    /// <inheritdoc />
    public partial class _120422 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "users");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_hash",
                table: "users",
                type: "varbinary(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "users",
                type: "varbinary(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "users");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
