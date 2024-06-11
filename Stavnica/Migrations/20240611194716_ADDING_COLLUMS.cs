using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stavnica.Migrations
{
    /// <inheritdoc />
    public partial class ADDING_COLLUMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "SportEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PayIn",
                table: "Bets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PayOut",
                table: "Bets",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "PayIn",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "PayOut",
                table: "Bets");
        }
    }
}
