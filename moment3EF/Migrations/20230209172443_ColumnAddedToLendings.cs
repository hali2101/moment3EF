using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moment3EF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAddedToLendings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InHouse",
                table: "Lendings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InHouse",
                table: "Lendings");
        }
    }
}
