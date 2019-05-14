using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankOfBrabant.Migrations
{
    public partial class Hoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RekeningOverzicht",
                columns: table => new
                {
                    Rekeningnummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Rentepercentage = table.Column<string>(nullable: true),
                    Saldo = table.Column<int>(nullable: false),
                    TypeRekening = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekeningOverzicht", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RekeningOverzicht");
        }
    }
}
