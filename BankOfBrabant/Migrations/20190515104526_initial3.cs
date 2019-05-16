using Microsoft.EntityFrameworkCore.Migrations;

namespace BankOfBrabant.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Shipper",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "AccountHolder");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverAccountId",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderAccountId",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AccountHolder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountID",
                table: "Transaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReceiverAccountId",
                table: "Transaction",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHolder_AccountId",
                table: "AccountHolder",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHolder_Account_AccountId",
                table: "AccountHolder",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Client_ClientId",
                table: "Products",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_ReceiverAccountId",
                table: "Transaction",
                column: "ReceiverAccountId",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHolder_Account_AccountId",
                table: "AccountHolder");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Client_ClientId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_ReceiverAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_AccountID",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ReceiverAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Products_ClientId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AccountHolder_AccountId",
                table: "AccountHolder");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReceiverAccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "SenderAccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountHolder");

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipper",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "AccountHolder",
                nullable: true);
        }
    }
}
