using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moment3EF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAddedToLending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Lendings",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Lendings");
        }
    }
}
