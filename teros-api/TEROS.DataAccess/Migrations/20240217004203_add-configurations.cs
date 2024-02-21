using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEROS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addconfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastSystemUpdate = table.Column<string>(type: "text", nullable: false),
                    LastUpdate = table.Column<string>(type: "text", nullable: false),
                    StatusDatabase = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
