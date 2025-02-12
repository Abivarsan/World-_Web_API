using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace World.Api.Migrations
{
    /// <inheritdoc />
    public partial class State_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Population",
                table: "States",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Population",
                table: "States");
        }
    }
}
