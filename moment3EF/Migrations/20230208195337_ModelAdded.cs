using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moment3EF.Migrations
{
    /// <inheritdoc />
    public partial class ModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lendings",
                columns: table => new
                {
                    LendingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfLending = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendings", x => x.LendingId);
                    table.ForeignKey(
                        name: "FK_Lendings_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lendings_AlbumId",
                table: "Lendings",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lendings");
        }
    }
}
