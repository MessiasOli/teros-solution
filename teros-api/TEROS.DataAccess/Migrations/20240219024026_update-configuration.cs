using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEROS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpdateCycle",
                table: "Configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateCycle",
                table: "Configurations");
        }
    }
}
