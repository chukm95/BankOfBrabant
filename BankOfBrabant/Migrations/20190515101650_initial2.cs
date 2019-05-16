using Microsoft.EntityFrameworkCore.Migrations;

namespace BankOfBrabant.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccountHolder_ClientID",
                table: "AccountHolder",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHolder_Client_ClientID",
                table: "AccountHolder",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHolder_Client_ClientID",
                table: "AccountHolder");

            migrationBuilder.DropIndex(
                name: "IX_AccountHolder_ClientID",
                table: "AccountHolder");
        }
    }
}
