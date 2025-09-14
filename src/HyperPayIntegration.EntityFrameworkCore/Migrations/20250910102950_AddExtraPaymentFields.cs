using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HyperPayIntegration.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardBin",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardExpiryMonth",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardExpiryYear",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardLast4",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerIp",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptor",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentBrand",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardBin",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CardExpiryMonth",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CardExpiryYear",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CardLast4",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "CustomerIp",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Descriptor",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentBrand",
                table: "PaymentTransactions");
        }
    }
}
