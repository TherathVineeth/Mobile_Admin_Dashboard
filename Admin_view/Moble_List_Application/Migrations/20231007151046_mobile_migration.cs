using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moble_List_Application.Migrations
{
    /// <inheritdoc />
    public partial class mobile_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mobile_Lists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobile_Lists", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mobile_Lists");
        }
    }
}
