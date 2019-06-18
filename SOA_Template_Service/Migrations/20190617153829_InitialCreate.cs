using Microsoft.EntityFrameworkCore.Migrations;

namespace ProviderService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarParts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartNumber = table.Column<int>(nullable: false),
                    PartName = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    ManufacturerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarParts");
        }
    }
}
